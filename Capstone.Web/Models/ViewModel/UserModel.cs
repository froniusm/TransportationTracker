using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public Dictionary<Route, List<WaypointTimeModel>> AllRoutes { get; set; }
    }

    public class WaypointTimeModel
    {
        public Waypoint Waypoint { get; set; }
        public List<Schedule> Times { get; set; }
    }

    public class RouteViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Day { get; set; }
        public bool IsPrivate { get; set; }

        public static List<SelectListItem> Days()
        {
            return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Sunday", Value = "Sunday" },
                    new SelectListItem { Text = "Monday", Value = "Monday" },
                    new SelectListItem { Text = "Tuesday", Value = "Tuesday" },
                    new SelectListItem { Text = "Wednesday", Value = "Wednesday" },
                    new SelectListItem { Text = "Thursday", Value = "Thursday" },
                    new SelectListItem { Text = "Friday", Value = "Friday" },
                    new SelectListItem { Text = "Saturday", Value = "Saturday" }
                };
        }
    }

    public class WaypointViewModel
    {
        public List<Waypoint> Waypoints;
        public string name;
    }

}
