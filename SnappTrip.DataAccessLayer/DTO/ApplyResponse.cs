using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.DTO
{
    public class ApplyResponse
    {
        public bool IsApplied { get; set; }
        public List<ApplyRule> ApplyRules { get; set; }
    }
}
