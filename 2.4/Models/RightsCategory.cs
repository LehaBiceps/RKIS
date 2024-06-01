using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class RightsCategory
    {
        public RightsCategory()
        {
            IdDrivers = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Driver> IdDrivers { get; set; }
    }
}
