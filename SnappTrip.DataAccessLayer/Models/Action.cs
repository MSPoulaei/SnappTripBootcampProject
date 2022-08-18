using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.Models
{
    public class Action
    {
        public long Id { get; set; }
        public decimal FixedDisplacementAmount { get; set; }
        public decimal PercentageDisplacementAmount { get; set; }
        public decimal MaximumDisplacementAmount { get; set; }

    }
}
