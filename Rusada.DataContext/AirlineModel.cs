using System;
using System.Collections.Generic;

namespace Rusada.DataContext
{
    public partial class AirlineModel
    {
        public AirlineModel()
        {
            Spotter = new HashSet<Spotter>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Spotter> Spotter { get; set; }
    }
}
