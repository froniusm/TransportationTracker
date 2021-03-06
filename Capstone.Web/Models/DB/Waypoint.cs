//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Waypoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Waypoint()
        {
            this.Schedules = new HashSet<Schedule>();
        }
    
        public int WaypointID { get; set; }
        public int RouteID { get; set; }
        public string Intersection { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
