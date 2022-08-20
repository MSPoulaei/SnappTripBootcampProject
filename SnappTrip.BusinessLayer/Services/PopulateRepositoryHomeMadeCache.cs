using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SnappTrip.BusinessLayer.Interfaces;
using SnappTrip.DataAccessLayer;
using SnappTrip.DataAccessLayer.Models;

namespace SnappTrip.BusinessLayer.Services
{
    public class PopulateRepositoryHomeMadeCache : IPopulateRepos
    {
        private readonly SnappTripDbContext context;

        public PopulateRepositoryHomeMadeCache(SnappTripDbContext context)
        {
            this.context = context;
        }

        public void Populate()
        {
            //Console.WriteLine("populating");
            //const string key = "rca";
            //List<RCA> RCAs=memoryCache.Get<List<RCA>>(key);
            context.Database.EnsureCreated();
            context.Database.Migrate();
            if (MemoryCache.RCAs == null || (DateTime.Now - MemoryCache.lastRequestTime).Minutes > 5)
            {
                MemoryCache.RCAs = getRCAsFromDB();
                MemoryCache.lastRequestTime = DateTime.Now;
            }

            //memoryCache.Set(key,RCAs,TimeSpan.FromSeconds(60));
        }

        private List<RCA> getRCAsFromDB()
        {
            //Console.WriteLine("getting from db");
            Dictionary<long, int> map_RuleId_indexRCAs = new Dictionary<long, int>();
            Dictionary<long, int> map_ActionId_indexRCAs = new Dictionary<long, int>();
            List<RCA> RCAs = new List<RCA>();
            var rules = context.Rules;
            int index = 0;
            foreach (var rule in rules)
            {
                RCAs.Add(new RCA()
                {
                    Rule = rule,
                    Conditions = new List<Condition>()
                });
                map_RuleId_indexRCAs.Add(rule.ID, index);
                map_ActionId_indexRCAs.Add(rule.ActionId, index);
                index++;
            }
            rules = null;
            var actions = context.Actions;
            foreach (var action in actions)
            {
                try
                {
                    RCAs[map_ActionId_indexRCAs[action.Id]].Action = action;
                }
                catch (Exception)
                {

                }
            }
            actions = null;
            var conditions = context.Conditions;
            foreach (var condition in conditions)
            {
                try
                {
                    RCAs[map_RuleId_indexRCAs[condition.RuleId]].Conditions.Add(condition);

                }
                catch (Exception)
                {

                }
            }
            return RCAs;
        }
    }
}
