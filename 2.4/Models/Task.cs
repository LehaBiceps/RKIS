using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Task
    {
        public Task()
        {
            Persontasks = new HashSet<Persontask>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly Date { get; set; }

        public virtual ICollection<Persontask> Persontasks { get; set; }
    }
}
