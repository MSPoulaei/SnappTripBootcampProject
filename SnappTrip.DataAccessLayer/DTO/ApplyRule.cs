using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.DTO
{
    public class ApplyRule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal Displacement { get; set; }
    }
}
