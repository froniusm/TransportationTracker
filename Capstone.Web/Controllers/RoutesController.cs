﻿using System;
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
            UserRoutesView model = new UserRoutesView();
            model= DAL.GetAllRoutes();
            return View("ViewRoutes", model);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AdminViewRoutes()
        {
            UserRoutesView model = new UserRoutesView();
            UserManager um = new UserManager();
            //model.AllRoutes = um.GetAllRoutes();

            return View("AdminViewRoutes", model);
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
            // Add to database here
            UserManager um = new UserManager();
            um.AddNewRoute(r);

            // Add route name to session
            Session["newRouteName"] = r.Name;

            return RedirectToAction("CreateRouteWaypoints", "Routes");


        }

        [AuthorizeRoles("Admin")]
        public ActionResult CreateRouteWaypoints()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeRoles("Admin")]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateRouteWaypoints(WaypointViewModel w)
        {
            w.name = (string)Session["newRouteName"];
            if (w.name == null)
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
    }
}