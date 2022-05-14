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
        public DateTime Date { get; set; }

        public  MakeEntity Make { get; set; }
        public virtual ModelEntity Model { get; set; }
    }
}
