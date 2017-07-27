using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using Capstone.Web.Models.ViewModel;
using Capstone.Web.Models.EntityManager;
using Capstone.Web.Crypto;
using Capstone.Web.Security;

namespace Capstone.Web.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        [AuthorizeRoles("Admin")]
        public ActionResult ManageUsers()
        {
            return View();
        }
    }
}