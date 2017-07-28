using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Capstone.Web.Models.DB;

namespace Capstone.Web.Models.ViewModel
{
    public class RegistrationModel
    {
        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        public string Salt { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "User Name")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }

    public class UserLoginView
    {
        [Key]
        public int SYSUserID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class UserRoutesView
    {
        public List<Route> PrivateRoutes { get; set; }
        public List<Route> PublicRoutes { get; set; }
        public List<Route> AllRoutes { get; set; }
    }

}