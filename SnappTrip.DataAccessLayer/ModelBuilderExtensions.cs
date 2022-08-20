using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SnappTrip.DataAccessLayer.Models;
using SnappTrip.DataAccessLayer.Models.Enums;
namespace SnappTrip.DataAccessLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Action>().HasData(
                new Models.Action
                {
                    Id = 3331,
                    FixedDisplacementAmount = 20000,
                    PercentageDisplacementAmount = 10,
                    MaximumDisplacementAmount = 25500
                },
                new Models.Action
                {
                    Id = 3332,
                    FixedDisplacementAmount = 10000,
                    PercentageDisplacementAmount = 5,
                    MaximumDisplacementAmount = 20000
                },
                new Models.Action
                {
                    Id = 3333,
                    FixedDisplacementAmount = 25000,
                    PercentageDisplacementAmount = 10,
                    MaximumDisplacementAmount = 40000
                },

                new Models.Action
                {
                    Id = 3334,
                    FixedDisplacementAmount = 1500.25m,
                    PercentageDisplacementAmount = 12.5m,
                    MaximumDisplacementAmount = 20000.243m
                }
            );


            modelBuilder.Entity<Rule>().HasData(
                new Rule()
                {
                    ID = 2000,
                    Name = "کاربر b2b",
                    ActionId = 3331,
                    RuleType = RuleType.DISCOUNT
                },
                new Rule()
                {
                    ID = 2001,
                    Name = "کاربر b2c",
                    ActionId = 3334,
                    RuleType = RuleType.MARKUP
                }
            );

            modelBuilder.Entity<Condition>().HasData(
                new Condition()
                {
                    Id = 1000,
                    ConditionType = ConditionType.UserType,
                    ConditionValue = (int)UserType.B2B,
                    RuleId = 2000
                },
                new Condition()
                {
                    Id = 1001,
                    ConditionType = ConditionType.UserType,
                    ConditionValue = (int)UserType.B2C,
                    RuleId = 2001
                }
            );

        }
    }
}
