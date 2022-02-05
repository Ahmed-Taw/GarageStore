using Garage.Business.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Business.Infrastructure.Iservices
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllCarsOrderedByDateAsync();
        Task<CarDetailsDTO> GetCarDetailsAsync(int id);
    }
}
