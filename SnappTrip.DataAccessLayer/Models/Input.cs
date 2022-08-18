using SnappTrip.DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip.DataAccessLayer.Models
{
    public class Input
    {
        public decimal price { get; set; }
        public UserType UserType { get; set; }
    }
}
