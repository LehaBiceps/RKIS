using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Car
    {
        public Car()
        {
            Routes = new HashSet<Route>();
        }

        public int Id { get; set; }
        public int IdTypeCar { get; set; }
        public string Name { get; set; } = null!;
        public string StateNumber { get; set; } = null!;
        public int NumberPassengers { get; set; }

        public virtual TypeCar IdTypeCarNavigation { get; set; } = null!;
        public virtual ICollection<Route> Routes { get; set; }
    }
}
