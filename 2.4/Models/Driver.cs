using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Routes = new HashSet<Route>();
            IdRightsCategories = new HashSet<RightsCategory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthdate { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public virtual ICollection<RightsCategory> IdRightsCategories { get; set; }
    }
}
