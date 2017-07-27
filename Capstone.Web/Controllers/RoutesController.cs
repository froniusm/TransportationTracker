using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models.ViewModel;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.EntityManager;

namespace Capstone.Web.Controllers
{
    public class RoutesController : Controller
    {
        // GET: Routes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewRoutes()
        {
            UserRoutesView model = new UserRoutesView();
            UserManager um = new UserManager();

            // model.publicRoutes;
            return View("ViewRoutes", model);
        }
        /*
         * public ActionResult ViewRoutes()
         *  
         *     UserRouteViewModel model = new UserRouteViewModel()
         *     model.PublicRoutes = UserManager.GetPublicROutes()
         *     
         *     if (userIsLoggedIn)          
         *           model.PrivateRoutes = UserManager.GetPrivateRoutes()
         *     else 
         *           model.PrivateRoutes = new List<Route>(); // Just so it's not null
         *         
         *    
         *    return View("ViewRoutes", model);
          */
    }
}