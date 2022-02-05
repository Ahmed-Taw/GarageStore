using Garage.DAL.Infrastructure.Entities;
using Garage.DAL.Sql.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Sql.DbContexts
{
    public class GarageSqlDbContext : DbContext
    {
        public GarageSqlDbContext(DbContextOptions<GarageSqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WarehouseLocationEntity>().Property(x => x.Lat).HasPrecision(10,8);
            builder.Entity<WarehouseLocationEntity>().Property(x => x.Long).HasPrecision(11, 8);

            builder.Seed();

        }

        public DbSet<CarEntity> Car { get; set; }
        public DbSet<WarehouseEntity> Warehouse { get; set; }
    }
}
