using Garage.DAL.Infrastructure.Entities;
using Garage.DAL.Infrastructure.Interfaces;
using Garage.DAL.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Sql.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly GarageSqlDbContext _dbContext;

        public CarRepository(GarageSqlDbContext dbContext)  
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CarEntity>> GetAllAsync()
        {
            var listOfEntities = await _dbContext.Set<CarEntity>().ToListAsync();
            return listOfEntities;
        }

        public async Task<CarEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<CarEntity>().Include(c => c.CarLocation)
                                                    .ThenInclude(cl => cl.Warehouse)
                                                    .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
