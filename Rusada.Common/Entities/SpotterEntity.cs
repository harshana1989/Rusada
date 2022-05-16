using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.Entities
{
    public class SpotterEntity
    {
       
        public int Id { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

    }
}
