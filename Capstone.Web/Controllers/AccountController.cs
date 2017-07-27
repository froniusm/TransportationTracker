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
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel USV)
        {

            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                List<string> hashSalt = UM.GetUserPassword(ULV.LoginName);

                if (hashSalt.Count == 0)
                {
                    ModelState.AddModelError("", "The user login and password combination is invalid.");
                    return View();
                }
                else
                {
                    HashProvider hasher = new HashProvider();
                    //The first item in the hashsalt list represents the hashed password. The second item represents the salt.
                    if (hasher.VerifyPasswordMatch(hashSalt[0], ULV.Password, hashSalt[1]))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                        string role = UM.GetUserRole(ULV.LoginName);
                        Session["userRole"] = role;
                        Session["userName"] = ULV.LoginName;
                        return RedirectToAction("Welcome", "Home", ULV);
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user login and password combination is invalid.");
                    }
                }
            }
            ModelState.AddModelError("", "The user login and password combination is invalid.");
            return View();
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}