using Garage.DAL.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Sql.Extensions
{
    public static class ModelBuilderExtensions
    {
        // for debugging purpose only
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // will add code to convert json to data in the table
            //string jsonData = "";
            //var warehouses = JsonConvert.DeserializeObject<List<WarehouseEntity>>(jsonData);
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

            //modelBuilder.Entity<CarLocationEntity>().HasData(carsLocations);
            //modelBuilder.Entity<CarEntity>().HasData(
            //    cars
            //   );

        }
    }
}
