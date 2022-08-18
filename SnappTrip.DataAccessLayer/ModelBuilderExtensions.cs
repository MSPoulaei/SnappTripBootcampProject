using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SnappTrip.DataAccessLayer.Models;

namespace SnappTrip.DataAccessLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Action>().HasData(
                new Models.Action
                {
                    Id=3331,
                    FixedDisplacementAmount=20000,
                    PercentageDisplacementAmount=10,
                    MaximumDisplacementAmount=25500
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
                    Id = 3333,
                    FixedDisplacementAmount = 25000,
                    PercentageDisplacementAmount = 10,
                    MaximumDisplacementAmount = 40000
                }
            );
            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
            //    new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
            //    new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
            //);
        }
    }
}
