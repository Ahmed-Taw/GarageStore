using Garage.DAL.Infrastructure.Entities;
using Garage.DAL.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Sql.Helpers
{
    public static class DataSeedingHelper
    {
        public static async void CheckAndSeed(string jsonData, IServiceProvider services)
        {
            using (
            var serviceScope = services.CreateScope())
            {
                var context = serviceScope
                              .ServiceProvider.GetService<GarageSqlDbContext>();

                if (!context.Warehouse.Any())
                {
                    var warehouses = JsonConvert.DeserializeObject<List<WarehouseEntity>>(jsonData);
                    //var cars = new List<CarEntity>();
                    //var carsLocations = new List<CarLocationEntity>();
                    //var warehouseLocations = new List<WarehouseLocationEntity>();
                    //for (int i = 0; i < warehouses.Count; i++)
                    //{
                    //    warehouses[i].Location.Id = i + 1;
                    //    warehouseLocations.Add(warehouses[i].Location);
                    //    warehouses[i].Cars.Id = i + 1;
                    //    carsLocations.Add(warehouses[i].Cars);
                    //    cars.AddRange(warehouses[i].Cars.Vehicles.Select(c => { c.CarLocationId = warehouses[i].Cars.Id; return c; }));
                    //};

                   await context.Warehouse.AddRangeAsync(warehouses);
                    context.Database.OpenConnection();
                    try
                    {
                       await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Car ON");
                       await context.SaveChangesAsync();
                       await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Car OFF");
                    }
                    finally
                    {
                        context.Database.CloseConnection();
                    }
                }
            }
        }
    }
}
