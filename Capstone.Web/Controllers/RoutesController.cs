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
            //model= DAL.GetAllRoutes();
            return View("ViewRoutes", urv);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AdminViewRoutes()
        {
            UserRoutesView urv = GetActiveUserRoutesView();
            //model.AllRoutes = um.GetAllRoutes();

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

            // Add route name to session
            Route route = new Route();
            route.Name = r.Name;
            route.Day = r.Day;
            route.IsPrivate = r.IsPrivate;
            Session["currentRoute"] = route;

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
        public ActionResult CreateRouteWaypointsPost(RouteViewModel rvm)
        {
            Route currentRoute = (Route)Session["currentRoute"];
            if (currentRoute.Name == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Add to database
                UserManager m = new UserManager();
            }
            return RedirectToAction("Index", "Home");
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