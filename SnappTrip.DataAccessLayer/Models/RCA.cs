using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.Models
{
    public class RCA
    {
        public Rule Rule { get; set; }
        public IList<Condition> Conditions { get; set; }
        public Action Action { get; set; }
    }
}
