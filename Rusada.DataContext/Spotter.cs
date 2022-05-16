using System;
using System.Collections.Generic;

namespace Rusada.DataContext
{
    public partial class Spotter
    {
        public int Id { get; set; }
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string? Registration { get; set; }
        public string? Location { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsActive { get; set; }

        public virtual Make? Make { get; set; }
        public virtual AirlineModel? Model { get; set; }
    }
}
