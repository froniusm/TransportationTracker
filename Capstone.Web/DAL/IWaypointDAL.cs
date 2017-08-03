using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.ViewModel;

namespace Capstone.Web.DAL
{
    public interface IWaypointDAL
    {
        UserRoutesView GetAllRoutes();
        int GetRouteID(string routeName);
        bool RouteNameTaken(string routeName);
        void CreateNewRoute(Route r, List<Waypoint> waypoints);
        List<Waypoint> GetWaypoints(int routeID);
        int GetWaypointID(string waypointName);
        void CreateSchedules(List<WaypointSchedule> schedules);
        List<Schedule> GetSchedules(int waypointID);
    }
}