using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SnappTrip.BusinessLayer.Interfaces;
using SnappTrip.DataAccessLayer.DTO;
using SnappTrip.DataAccessLayer.Models;
using SnappTrip.DataAccessLayer.Models.Enums;

namespace SnappTrip.BusinessLayer.Services
{
    public class ApplyRepository : IApplyRepos
    {

        public ApplyRepository()
        {
        }
        public ApplyResponse GetApplyResponse(Input input)
        {
            decimal currentPrice = input.price;
            UserType userType = input.UserType;
            ApplyResponse response = new ApplyResponse()
            {
                ApplyRules = new List<ApplyRule>(),
                IsApplied = false
            };
            var RCAs = MemoryCache.RCAs;
            int sequence = 1;
            foreach (var rca in RCAs)
            {
                var conditions = rca.Conditions;
                bool isMatch = true;
                foreach (var condition in conditions)
                {
                    switch (condition.ConditionType)
                    {
                        case ConditionType.UserType:
                            if ((int)userType!=condition.ConditionValue)
                            {
                                isMatch = false;
                            }  
                            break;
                        default:
                            break;
                    }
                    if (!isMatch)
                    {
                        break;
                    }
                }
                if (isMatch)
                {
                    decimal displacement = getDisplacement(currentPrice, rca.Action, rca.Rule.RuleType);
                    ApplyRule applyRule = new ApplyRule()
                    {
                        Id=rca.Rule.ID,
                        Name=rca.Rule.Name,
                        OldPrice=currentPrice,
                        Sequence=sequence,
                        Displacement=displacement,
                        NewPrice=currentPrice+displacement
                    };
                    response.IsApplied = true;
                    response.ApplyRules.Add(applyRule);
                    currentPrice = applyRule.NewPrice;
                    sequence++;
                }
            }
            return response;
        }

        public UserType GetUserType(string userType)
        {
            return (UserType)Enum.Parse(typeof(UserType), userType,true);
        }
        private decimal getDisplacement(decimal oldPrice, DataAccessLayer.Models.Action action,RuleType ruleType)
        {
            decimal res= Math.Min(action.FixedDisplacementAmount + oldPrice * action.PercentageDisplacementAmount / 100, action.MaximumDisplacementAmount); ;
            switch (ruleType)
            {
                case RuleType.DISCOUNT:
                    return -res;
                case RuleType.MARKUP:
                    return res;
                default:
                    break;
            }
            return res;
        }
    }
}
