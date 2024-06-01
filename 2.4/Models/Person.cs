using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Person
    {
        public Person()
        {
            Persontasks = new HashSet<Persontask>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Persontask> Persontasks { get; set; }
    }
}
