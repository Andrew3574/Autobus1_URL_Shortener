using Autobus1_Burlakov.Data;
using Microsoft.EntityFrameworkCore;

namespace Autobus1_Burlakov.Utilities.Extensions
{
    public static class DatabaseExtensions
    {
        public static void InitMigration(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<Autobus1dbContext>();
            dbContext.Database.Migrate();
        }
    }
}
