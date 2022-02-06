using AutoMapper;
using Garage.Business.Infrastructure.CustomExceptions;
using Garage.Business.Infrastructure.DTOs;
using Garage.Business.Services;
using Garage.DAL.Infrastructure.Entities;
using Garage.DAL.Infrastructure.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Garage.Business.Test.ServicesTest
{
    public class CarServiceTest
    {
        private readonly Mock<ICarRepository> _mockCarRepository;
        private Mock<IMapper> _mockMapper;
        private readonly CarService _carService;
        public CarServiceTest()
        {
            _mockCarRepository = new Mock<ICarRepository>();
            _mockMapper = new Mock<IMapper>();
            _carService = new CarService(_mockCarRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllCarsOrderedByDateAsync_whenNoExceptions_ReturnListOfCars()
        {
            var mockDataDTOs = new List<CarDTO>()
            {
                new CarDTO(){ Id = 1, DateAdded = DateTime.Now, Licensed = true, Make = "TestMake", Model="TestModel", Price = 1111.22, YearModel=2003 }
            };
            var mockDataEntities = new List<CarEntity>()
            {
                new CarEntity(){ Id = 1, DateAdded = DateTime.Now, Licensed = true, Make = "TestMake", Model="TestModel", Price = 1111.22, YearModel=2003 }
            };

            _mockCarRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(mockDataEntities);
            _mockMapper.Setup(m => m.Map<List<CarDTO>>(mockDataEntities)).Returns(mockDataDTOs);
            var cars = await _carService.GetAllCarsOrderedByDateAsync();

            Assert.NotNull(cars);
            Assert.Equal(mockDataDTOs, cars);
        }

        [Fact]
        public void GetAllCarsOrderedByDateAsync_whenExceptionHappen_ThrowException()
        {

            _mockCarRepository.Setup(r => r.GetAllAsync()).Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _carService.GetAllCarsOrderedByDateAsync());
        }

        [Fact]
        public async Task GetCarDetailsAsync_whenExistsAndNoExceptions_ReturnCarDetailsObject()
        {
            var carId = 1;
            var carDetailsDTO = new CarDetailsDTO() { Id = 1, DateAdded = DateTime.Now, Licensed = true, Make = "TestMake", Model = "TestModel", Price = 1111.22, YearModel = 2003 };
            var carEntity = new CarEntity() { Id = 1, DateAdded = DateTime.Now, Licensed = true, Make = "TestMake", Model = "TestModel", Price = 1111.22, YearModel = 2003 };
      

            _mockCarRepository.Setup(r => r.GetByIdAsync(carId)).ReturnsAsync(carEntity);
            _mockMapper.Setup(m => m.Map<CarDetailsDTO>(carEntity)).Returns(carDetailsDTO);
            var carObject = await _carService.GetCarDetailsAsync(carId);

            Assert.NotNull(carObject);
            Assert.Equal(carDetailsDTO, carObject);
        }

        [Fact]
        public void GetCarDetailsAsync_whenNotExists_ThrowCustomNotFoundException()
        {
            var carId = 1;

            _mockCarRepository.Setup(r => r.GetByIdAsync(carId)).ReturnsAsync(null as CarEntity);
             
            Assert.ThrowsAsync<ResourceNotFoundException>(() => _carService.GetCarDetailsAsync(carId));
        }

        [Fact]
        public void GetCarDetailsAsync_whenExceptionHappen_ThrowException()
        {
            var carId = 1;

            _mockCarRepository.Setup(r => r.GetByIdAsync(carId)).Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _carService.GetCarDetailsAsync(carId));
        }

    }
}
