﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models.DB;
using Capstone.Web.Models.ViewModel;

namespace Capstone.Web.DAL
{
    public interface IWaypointDAL
    {
        HashSet<Schedule> GetSchedules(int waypointID);
        List<Route> GetAllRoutes();
    }
}