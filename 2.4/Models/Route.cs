using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Route
    {
        public int Id { get; set; }
        public int IdDriver { get; set; }
        public int IdCar { get; set; }
        public int IdItinerary { get; set; }
        public int NumberPassengers { get; set; }

        public virtual Car IdCarNavigation { get; set; } = null!;
        public virtual Driver IdDriverNavigation { get; set; } = null!;
        public virtual Itinerary IdItineraryNavigation { get; set; } = null!;
    }
}
