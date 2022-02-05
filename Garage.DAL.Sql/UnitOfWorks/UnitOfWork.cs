using Garage.DAL.Infrastructure.Interfaces;
using Garage.DAL.Sql.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Sql.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GarageSqlDbContext _dbContext;

        public UnitOfWork(GarageSqlDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
