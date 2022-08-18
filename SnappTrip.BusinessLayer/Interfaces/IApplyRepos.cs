using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnappTrip.DataAccessLayer.DTO;
using SnappTrip.DataAccessLayer.Models;
using SnappTrip.DataAccessLayer.Models.Enums;

namespace SnappTrip.BusinessLayer.Interfaces
{
    public interface IApplyRepos
    {
        public ApplyResponse GetApplyResponse(Input input);
        public UserType GetUserType(string UserType);
    }
}
