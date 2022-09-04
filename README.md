# SnappTripBootcampProject

## Overview

This project is written in C# using ASP.NET 6 and Entity FrameworkCore 6 as ORM and Docker for deployment

## Installation

1.clone the project

2.cd into the project folder

3.run this command:

```
docker-compose up -d
```

4.open your browser

5.go to this url:
http://localhost:80/swagger/index.html

6.test the api


## Data in database:

there are already some data seeded:

```
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
```
