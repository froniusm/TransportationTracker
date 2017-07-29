using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.ViewModel;

namespace Capstone.Web.DAL
{
    public class WaypointDAL : IWaypointDAL
    {
        private string connectionString;
        private const string SQL_GetSchedules = "SELECT * FROM Schedules WHERE WaypointID = @waypointID;";

        public WaypointDAL(string connectionString)
        {
            string sub = connectionString.Substring(172);
            /* This substrings the connectionString to remove all of Entity Framework's garbage and nonsense.  
            Entity framework generates a connectionstring that Ninject can't recognize, so we substringed out anything except for...
             data source=e23b13d1-adfa-4117-9ccf-a7bc00f3296d.sqlserver.sequelizer.com;initial catalog=dbe23b13d1adfa41179ccfa7bc00f3296d;persist security info=True;user id=gkrnlqmlretldcpq;password=me7tqdUNE55Wwqgr5QnAWYeborqFbARCBNMSYfukMdaFQPdzdBFzZiZua5f8VnLd;
              */
            sub = sub.Substring(0, 250);
            this.connectionString = sub;
        }

        public UserRoutesView GetAllRoutes()
        {
            UserRoutesView routes = new UserRoutesView();
            Dictionary<Route, List<WaypointTimeModel>> allRoutes = new Dictionary<Route, List<WaypointTimeModel>>();
            routes.AllRoutes = allRoutes;

            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                
                List<Route> tempRouteList = new List<Route>();
                tempRouteList = db.Routes.ToList();
                foreach (Route route in tempRouteList)
                {
                    List<WaypointTimeModel> waypointTimesList = new List<WaypointTimeModel>();
                    foreach (Waypoint waypoint in route.Waypoints)
                    {
                        WaypointTimeModel waypointTimes = new WaypointTimeModel();
                        waypointTimes.Waypoint = waypoint;

                        List<Schedule> schedules = new List<Schedule>();

                        waypointTimes.Times = db.Schedules.Where(i => i.WaypointID == (waypoint.WaypointID)).ToList();
                        waypointTimesList.Add(waypointTimes);
                    }
                    allRoutes[route] = waypointTimesList;
                }
            }
            return routes;
        }

        public HashSet<Schedule> GetSchedules(int waypointID)
        {
            HashSet<Schedule> schedules = new HashSet<Schedule>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetSchedules, conn);
                    cmd.Parameters.AddWithValue("@waypointID", waypointID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        schedules.Add(PopulateScheduleObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


            return schedules;
        }

        public Schedule PopulateScheduleObject(SqlDataReader reader)
        {
            return new Schedule()
            {
                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                Sequence = Convert.ToInt32(reader["Sequence"]),
                ETA = TimeSpan.Parse(Convert.ToString(reader["ETA"])),
                WaypointID = Convert.ToInt32(reader["WaypointID"])
            };
        }

    }
}