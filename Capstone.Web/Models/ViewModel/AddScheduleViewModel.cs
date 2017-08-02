using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models.DB;

namespace Capstone.Web.Models.ViewModel
{
    public class AddScheduleViewModel
    {
        public Dictionary<Waypoint, List<Schedule>> WaypointSchedules { get; set; }
    }
}