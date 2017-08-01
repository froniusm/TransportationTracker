using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.ViewModel;
using System.Configuration;

namespace Capstone.Web.DAL
{
    public class WaypointDAL : IWaypointDAL
    {
        private string connectionString;
        private const string SQL_CreateNewRoute = "INSERT INTO Routes VALUES(@Name, @Day, @IsPrivate);";
        private const string SQL_CreateNewWaypoints = "INSERT INTO Waypoints VALUES(@RouteID, @Intersection, @Longitude, @Latitude);";
        private const string SQL_GetRouteID = "SELECT RouteID FROM Routes WHERE Name = @Name;";
        private const string SQL_GetWaypoints = "SELECT * FROM Waypoints WHERE RouteID = @RouteID";
        private const string SQL_GetSchedules = "SELECT * FROM Schedules WHERE WaypointID = @waypointID;";

        public WaypointDAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["TransportationDAL"].ConnectionString;
        }

        public WaypointDAL(string connectionString)
        {
            string[] splitConnectionStrings = connectionString.Split(';');
            string dataSource = "";
            string initialCatalog = "";
            string persistSecurity = "";
            string userId = "";
            string password = "";

            //This finds all of the information ninject needs for dependency injection and trims all the added
            //information that entity framework inserts into the connectionstring
            foreach (var splitString in splitConnectionStrings)
            {
                if (splitString.Contains("data source"))
                {
                    string data = splitString.Substring(28);
                    dataSource = data;
                }
                if (splitString.Contains("initial catalog"))
                {
                    initialCatalog = splitString;
                }
                if (splitString.Contains("persist security"))
                {
                    persistSecurity = splitString;
                }
                if (splitString.Contains("user id"))
                {
                    userId = splitString;
                }
                if (splitString.Contains("password"))
                {
                    password = splitString;
                }
            }
            this.connectionString = dataSource + initialCatalog + persistSecurity + userId + password;
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

        public int GetRouteID(string routeName)
        {
            int routeID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetRouteID, conn);
                    cmd.Parameters.AddWithValue("@Name", routeName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        routeID = Convert.ToInt32(reader["RouteID"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return routeID;
        }

        // CreateNewRoute() creates the route AND its waypoints
        public void CreateNewRoute(Route r, List<Waypoint> waypoints)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateNewRoute, conn);
                    cmd.Parameters.AddWithValue("@Name", r.Name);
                    cmd.Parameters.AddWithValue("@Day", r.Day);
                    cmd.Parameters.AddWithValue("@IsPrivate", r.IsPrivate);

                    cmd.ExecuteNonQuery();

                    foreach (Waypoint w in waypoints)
                    {
                        int routeID = GetRouteID(r.Name);
                        cmd = new SqlCommand(SQL_CreateNewWaypoints, conn);
                        cmd.Parameters.AddWithValue("@RouteID", routeID);
                        cmd.Parameters.AddWithValue("@Intersection", w.Intersection);
                        cmd.Parameters.AddWithValue("@Longitude", w.Longitude);
                        cmd.Parameters.AddWithValue("@Latitude", w.Latitude);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }  

        public Route PopulateRouteObject(SqlDataReader reader)
        {
            return new Route()
            {
                RouteID = Convert.ToInt32(reader["RouteID"]),
                Name = Convert.ToString(reader["Name"]),
                Day = Convert.ToString(reader["Day"]),
                IsPrivate = Convert.ToBoolean(reader["IsPrivate"])
            };
        }

        public List<Waypoint> GetWaypoints(int routeID)
        {
            List<Waypoint> waypoints = new List<Waypoint>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWaypoints, conn);
                    cmd.Parameters.AddWithValue("@RouteID", routeID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        waypoints.Add(PopulateWaypointObject(reader));
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

            return waypoints;
        }

        //public int GetWaypointID(string waypointName) // TODO for 8/1/17

        public Waypoint PopulateWaypointObject(SqlDataReader reader)
        {
            return new Waypoint()
            {
                WaypointID = Convert.ToInt32(reader["WaypointID"]),
                RouteID = Convert.ToInt32(reader["RouteID"]),
                Intersection = Convert.ToString(reader["Intersection"]),
                Longitude = Convert.ToDecimal(reader["Longitude"]),
                Latitude = Convert.ToDecimal(reader["Latitude"])
            };
        }

        // public void CreateSchedules(List<Schedules>) TODO for 8/1/17  
        // Schedules has the FK for waypointID within it
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