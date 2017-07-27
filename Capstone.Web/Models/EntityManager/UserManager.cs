using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.ViewModel;

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
                SYSUser SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                SYSUserRole SR = db.SYSUserRoles.Where(r => r.SYSUserID.Equals(SU.SYSUserID))?.FirstOrDefault();
                LOOKUPRole LR = db.LOOKUPRoles.Where(i => i.LOOKUPRoleID.Equals(SR.LOOKUPRoleID))?.FirstOrDefault();
                return LR.RoleName;
            }
        }
        
    }
}