using SnappTrip.DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.Models
{
    public class Condition
    {
        public long Id { get; set; }
        public ConditionType ConditionType { get; set; }
        public int ConditionValue { get; set; }
        public long RuleId { get; set; }
        public virtual Rule Rule { get; set; }

    }
}
