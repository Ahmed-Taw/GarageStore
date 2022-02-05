using Garage.DAL.Infrastructure.Interfaces;
using Garage.DAL.Sql.DbContexts;
using Garage.DAL.Sql.Repositories;
using Garage.DAL.Sql.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Sql.Extensions
{
    public static class ServiceCOllectionExtensions
    {
        public static IServiceCollection _services { get; set; }
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarRepository, CarRepository>();
        }

        public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GarageSqlDbContext>(options =>
              options.UseSqlServer(connectionString));
        }


        public static IHost MigrateDatabaseToLatestVersion(this IHost host)
        {
            var serviceScopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<GarageSqlDbContext>();
                dbContext.Database.Migrate();
            }
            return host;
        }

    }
}
