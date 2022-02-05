using Garage.DAL.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.DAL.Infrastructure.Interfaces
{
    public interface ICarRepository  
    {
        Task<CarEntity> GetByIdAsync(int id);
        Task<IEnumerable<CarEntity>> GetAllAsync();
    }
}
