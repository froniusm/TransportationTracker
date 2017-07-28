using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models.ViewModel;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.EntityManager;
using Capstone.Web.Security;

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
            UserManager um = new UserManager();
            UserRoutesView model = new UserRoutesView();

            model.PublicRoutes = um.GetPublicRoutes();      
            model.AllRoutes = um.GetAllRoutes();
            if (Session["userName"] != null)
            {
                model.PrivateRoutes = um.GetPrivateRoutes(Session["userName"].ToString());
            }    

            // model.publicRoutes;
            return View("ViewRoutes", model);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AdminViewRoutes()
        {
            UserRoutesView model = new UserRoutesView();
            UserManager um = new UserManager();
            model.AllRoutes = um.GetAllRoutes();

            return View("AdminViewRoutes", model);
        }
    }
}