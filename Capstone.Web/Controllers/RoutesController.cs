using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models.ViewModel;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.EntityManager;
using Capstone.Web.Security;
using Capstone.Web.DAL;
using System.Configuration;

namespace Capstone.Web.Controllers
{
    public class RoutesController : Controller
    {
        private IWaypointDAL DAL;

        public RoutesController(IWaypointDAL waypointDAL)
        {
            this.DAL = waypointDAL;
        }

        // GET: Routes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewRoutes()
        {
            UserRoutesView urv = GetActiveUserRoutesView();
            return View("ViewRoutes", urv);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AdminViewRoutes()
        {
            UserRoutesView urv = GetActiveUserRoutesView();
            return View("AdminViewRoutes", urv);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult CreateRoute()
        {
            UserManager um = new UserManager();
            List<Route> allExistingRoutes = um.GetAllRoutes();
            List<string> allRouteNames = new List<string>();
            foreach (Route r in allExistingRoutes)
            {
                allRouteNames.Add(r.Name);
            }
            TempData["allRouteNames"] = allRouteNames;
            return View();
        }

        [HttpPost]
        [AuthorizeRoles("Admin")]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateRoute(RouteViewModel r)
        {
            /* If there's already a route with the same name, flag that using TempData,
            and kick them back to the menu again.  Route names must be unique.           
            Note that the SQL Database doesn't contain a unique constraint for route names as of 8/3/17
             */
            WaypointDAL dal = new WaypointDAL();
            if (dal.RouteNameTaken(r.Name))
            {
                TempData["RouteNameTaken"] = true;
                return RedirectToAction("CreateRoute");
            }

            // Add route name to session
            Route route = new Route();
            route.Name = r.Name;
            route.Day = r.Day;
            route.IsPrivate = r.IsPrivate;
            Session["currentRoute"] = route;
            Session["currentRouteName"] = route.Name;

            UserRoutesView userRoutesView = GetActiveUserRoutesView();
            List<WaypointTimeModel> waypointTimeModel = new List<WaypointTimeModel>();
            userRoutesView.AllRoutes[route] = waypointTimeModel;

            return RedirectToAction("CreateRouteWaypoints", userRoutesView);
        }

        [AuthorizeRoles("Admin")]
        [ActionName("CreateRouteWaypoints"), HttpGet]
        public ActionResult CreateRouteWaypoints()
        {
            return View();
        }


        [AuthorizeRoles("Admin")]
        [ValidateAntiForgeryToken()]
        [ActionName("CreateRouteWaypoints"), HttpPost]
        public ActionResult CreateRouteWaypoints(AddWaypointsViewModel vm)
        {
            Route currentRoute = (Route)Session["currentRoute"];
            if (currentRoute == null)
            {
                // Case where there was no route, which means that the user skipped the 1st step of creating a route
                return HttpNotFound();
            }

            WaypointDAL dal = new WaypointDAL();
            dal.CreateNewRoute(currentRoute, vm.Waypoints);

            return RedirectToAction("CreateRouteSchedules", "Routes", new { name = currentRoute.Name });
        }

        [AuthorizeRoles("Admin")]
        public ActionResult CreateRouteSchedules(string name)
        {

            WaypointDAL dal = new WaypointDAL();

            int routeId = dal.GetRouteID(name);
            List<Waypoint> waypoints = new List<Waypoint>();
            waypoints = dal.GetWaypoints(routeId);

            List<WaypointTimeModel> lwpt = new List<WaypointTimeModel>();
            foreach (var waypoint in waypoints)
            {
                WaypointTimeModel wpt = new WaypointTimeModel();
                wpt.Times = dal.GetSchedules(waypoint.WaypointID);
                wpt.Waypoint = waypoint;
                lwpt.Add(wpt);
            }

            return View(lwpt);
        }

        [AuthorizeRoles("Admin")]
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult CreateRouteSchedules(List<WaypointSchedule> newSchedule)
        {
            //Add to database
            WaypointDAL dal = new WaypointDAL();
            dal.CreateSchedules(newSchedule);
            //Redirect to home or success page
            return RedirectToAction("CreateRouteSchedules", "Routes", new { name = Session["currentRouteName"] });
        }

        // Returns the UserRoutesView. If there isn't one, then one is created.
        private UserRoutesView GetActiveUserRoutesView()
        {
            if (Session["UserRoutesView"] == null)
            {
                // Populate UserRoutesView (Route, Waypoints) with EF
                UserRoutesView usv = DAL.GetAllRoutes(); // Populate last section of schedules With DAL
                Session["UserRoutesView"] = usv;
            }

            return (UserRoutesView)Session["UserRoutesView"];
        }
    }
}