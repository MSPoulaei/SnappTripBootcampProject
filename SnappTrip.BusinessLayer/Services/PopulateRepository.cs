using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SnappTrip.BusinessLayer.Interfaces;
using SnappTrip.DataAccessLayer;
using SnappTrip.DataAccessLayer.Models;

namespace SnappTrip.BusinessLayer.Services
{
    public class PopulateRepository : IPopulateRepos
    {
        private readonly IMemoryCache memoryCache;
        private readonly SnappTripDbContext context;

        public PopulateRepository(IMemoryCache memoryCache, SnappTripDbContext context)
        {
            this.memoryCache = memoryCache;
            this.context = context;
        }

        public void Populate()
        {
            Console.WriteLine("populating");
            const string key = "rca";
            List<RCA> RCAs=memoryCache.Get<List<RCA>>(key);
            if (RCAs == null)
            {
                RCAs=getRCAsFromDB();
            }
            memoryCache.Set(key,RCAs,TimeSpan.FromSeconds(60));
        }

        private List<RCA> getRCAsFromDB()
        {
            Console.WriteLine("getting from db");
            Dictionary<long, int> map_RuleId_indexRCAs = new Dictionary<long, int>();
            Dictionary<long, int> map_ActionId_indexRCAs = new Dictionary<long, int>();
            List<RCA> RCAs = new List<RCA>();
            RCAs.Add(new RCA()
            {
                Rule=new Rule()
                {
                    ActionId=21,
                    ID=0,
                    Name="adgsad",
                    RuleType=DataAccessLayer.Models.Enums.RuleType.MARKUP
                },
                Action=null,
                Conditions=null,
            });
            var rules = context.Rules;
            int index = 0;
            foreach (var rule in rules)
            {
                RCAs.Add(new RCA()
                {
                    Rule=rule,
                    Conditions=new List<Condition>()
                });
                map_RuleId_indexRCAs.Add(rule.ID, index);
                map_ActionId_indexRCAs.Add(rule.ActionId, index);
                index++;
            }
            rules = null;
            var actions = context.Actions;
            foreach (var action in actions)
            {
                RCAs[map_ActionId_indexRCAs[action.Id]].Action=action;
            }
            actions = null;
            var conditions = context.Conditions;
            foreach (var condition in conditions)
            {
                RCAs[map_RuleId_indexRCAs[condition.RuleId]].Conditions.Add(condition);
            }
            return RCAs;
        }
    }
}
