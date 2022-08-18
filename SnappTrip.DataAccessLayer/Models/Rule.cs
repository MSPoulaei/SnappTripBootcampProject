using SnappTrip.DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.Models
{
    public class Rule
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public RuleType RuleType { get; set; }
        public long ActionId { get; set; }
        public virtual Action Action { get; set; }
    }
}
