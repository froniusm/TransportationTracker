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

namespace Capstone.Web.Controllers
{
    public class AccountController : Controller
    {      
        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel USV) {

            if (ModelState.IsValid) {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName)) {
                    HashProvider hasher = new HashProvider();
                    string hashedPassword = hasher.HashPassword(USV.Password);
                    USV.Salt = hasher.SaltValue;
                    USV.Password = hashedPassword;
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.FirstName, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "The user login and password combination is invalid.");
                }
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user login and password combination is invalid.");
                    }
                }
            }

            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}