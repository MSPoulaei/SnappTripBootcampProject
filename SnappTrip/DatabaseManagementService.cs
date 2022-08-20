using Microsoft.EntityFrameworkCore;
using SnappTrip.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTrip
{
    public static class DatabaseManagementService
    {
        // Getting the scope of our database context
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    // Takes all of our migrations files and apply them against the database in case they are not implemented
            //    serviceScope.ServiceProvider.GetService<SnappTripDbContext>().Database.Migrate();
            //}
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<SnappTripDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
