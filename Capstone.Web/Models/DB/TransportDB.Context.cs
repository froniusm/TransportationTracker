﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capstone.Web.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TransportationDBEntities : DbContext
    {
        public TransportationDBEntities()
            : base("name=TransportationDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOOKUPRole> LOOKUPRoles { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SYSUser> SYSUsers { get; set; }
        public virtual DbSet<SYSUserProfile> SYSUserProfiles { get; set; }
        public virtual DbSet<SYSUserRole> SYSUserRoles { get; set; }
        public virtual DbSet<Waypoint> Waypoints { get; set; }

        public System.Data.Entity.DbSet<Capstone.Web.Models.ViewModel.UserLoginView> UserLoginViews { get; set; }
    }
}