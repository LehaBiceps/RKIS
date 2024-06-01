using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Itinerary
    {
        public Itinerary()
        {
            Routes = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Route> Routes { get; set; }
    }
}
