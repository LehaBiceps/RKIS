using System;
using System.Collections.Generic;

namespace _2._4.Models
{
    public partial class Persontask
    {
        public int Id { get; set; }
        public int IdTask { get; set; }
        public int IdPerson { get; set; }

        public virtual Task IdPersonNavigation { get; set; } = null!;
        public virtual Person IdTaskNavigation { get; set; } = null!;
    }
}
