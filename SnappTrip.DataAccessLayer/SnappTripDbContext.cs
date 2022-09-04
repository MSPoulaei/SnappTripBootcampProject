using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnappTrip.DataAccessLayer.Models;

namespace SnappTrip.DataAccessLayer
{
    public class SnappTripDbContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        public SnappTripDbContext(DbContextOptions<SnappTripDbContext> options) : base(options)
        {
        }
        //public SnappTripDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server with connection string from app settings
        //    options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=SnappTripDB;Integrated Security=SSPI", builder =>
        //    {
        //        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //    });
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}
