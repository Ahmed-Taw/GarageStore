using AutoMapper;
using Garage.Business.Infrastructure.DTOs;
using Garage.Business.Infrastructure.Iservices;
using Garage.DAL.Infrastructure.Entities;
using Garage.DAL.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Business.Infrastructure.CustomExceptions;

namespace Garage.Business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarDTO>> GetAllCarsOrderedByDateAsync()
        {
            var carEntities = await _carRepository.GetAllAsync();

            return   _mapper.Map<List<CarDTO>>(carEntities.OrderBy(c => c.DateAdded));
        }

        public async Task<CarDetailsDTO> GetCarDetailsAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car is null)
                throw new ResourceNotFoundException();
            return _mapper.Map<CarDetailsDTO>(car);
        }
    }
}
