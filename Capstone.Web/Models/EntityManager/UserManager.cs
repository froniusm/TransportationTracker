using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.ViewModel;
using Capstone.Web.DAL;

namespace Capstone.Web.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(RegistrationModel user)
        {

            using (TransportationDBEntities db = new TransportationDBEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.Salt = user.Salt;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;

                try
                {
                    db.SYSUsers.Add(SU);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                SYSUserProfile SUP = new SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.Email = user.Email;
                SUP.PhoneNumber = user.PhoneNumber;
                SUP.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;

                db.SYSUserProfiles.Add(SUP);
                db.SaveChanges();


                if (user.LOOKUPRoleID > 0)
                {
                    SYSUserRole SUR = new SYSUserRole();
                    SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                    SUR.SYSUserID = user.SYSUserID;
                    SUR.IsActive = true;
                    SUR.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;

                    db.SYSUserRoles.Add(SUR);
                    db.SaveChanges();
                }
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }

        public List<string> GetUserPassword(string loginName)
        {
            using (TransportationDBEntities db = new TransportationDBEntities()) // Gets the corresponding password from the database for a login name using LINQ query
            {
                var user = db.SYSUsers.Where(m => m.LoginName.ToLower().Equals(loginName));

                //The first item in the hashsalt list represents the hashed password. The second item represents the salt.
                List<string> hashSalt = new List<string>();
                if (user.Any())
                {
                    hashSalt.Add(user.FirstOrDefault().PasswordEncryptedText);
                    hashSalt.Add(user.FirstOrDefault().Salt);
                    return hashSalt;
                }
                else
                {
                    return hashSalt;
                }
            }
        }
        //Only allows administrator to access the maintenance page
        public bool IsUserInRole(string loginName, string roleName)
        {
            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                SYSUser SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (SU != null)
                {
                    var roles = from q in db.SYSUserRoles
                                join r in db.LOOKUPRoles on q.LOOKUPRoleID equals r.LOOKUPRoleID
                                where r.RoleName.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
                                select r.RoleName;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public string GetUserRole(string loginName)
        {
            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                string role = db.SYSUsers.First(u => u.LoginName == loginName).SYSUserRoles.First().LOOKUPRole.RoleName;
                return role;
            }
        }

        public List<Route> GetPublicRoutes()
        {
            List<Route> routes = new List<Route>();

            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                routes = db.Routes.Where(m => m.IsPrivate == false)?.AsEnumerable().ToList();
            }
            return routes;
        }

        public List<Route> GetPrivateRoutes(string loginName)
        {
            List<Route> routes = new List<Route>();

            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                routes = db.SYSUsers.First(u => u.LoginName == loginName).Routes.ToList();
            }
            return routes;
        }

        public List<Route> GetAllRoutes()
        {
            List<Route> routes = new List<Route>();

            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                routes = db.Routes.ToList();
                foreach (Route route in routes)
                {
                    route.Waypoints = db.Waypoints.Where(i => i.RouteID.Equals(route.RouteID)).ToList();
                    foreach (Waypoint waypoint in route.Waypoints)
                    {

                        // WaypointSQLDAL dal = new WaypointSQLDAL(dbConnectionString);
                        // waypoint.Schedules = dal.Return_Schedules_(Waypoint.ID);
                    }
                }
            }
            return routes;
        }

        public void AddNewRoute(RouteViewModel model)
        {
            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                Route r = new Route();

                r.Day = model.Day;
                r.Name = model.Name;
                r.IsPrivate = model.IsPrivate;

                try
                {
                    db.Routes.Add(r);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private int GetUserID(string loginName) // NOT FINISHED YET
        {
            int userID = 0;
            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                userID = db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).First().SYSUserID;
            }
            return userID;
        }

        private int GetRoleID(string roleName)
        {
            int roleID = 0;
            using (TransportationDBEntities db = new TransportationDBEntities())
            {
                roleID = db.LOOKUPRoles.First(m => m.RoleName == roleName).LOOKUPRoleID;
            }
            return roleID;
        }
    }
}