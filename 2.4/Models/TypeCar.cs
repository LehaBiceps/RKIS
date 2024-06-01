using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class TypeCar
    {
        public TypeCar()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
