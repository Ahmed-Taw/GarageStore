using Garage.Business.Infrastructure.CustomExceptions;
using Garage.Business.Infrastructure.DTOs;
using Garage.Business.Infrastructure.Iservices;
using Garage.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Garage.Test.ControllersTest
{
    public class CarControllerTest
    {
        private readonly Mock<ICarService> _mockCarService;
        private readonly CarsController _carController; 
        public CarControllerTest()
        {
            _mockCarService = new Mock<ICarService>();
          

            _carController = new CarsController(_mockCarService.Object);
        }

        [Fact]
        public async Task GetCars_WhenNoExceptions_ReturnOkResultWithListOfCars()
        {
            var mockData = new List<CarDTO>()
            {
                new CarDTO(){ Id = 1, DateAdded = DateTime.Now, Licensed = true, Make = "TestMake", Model="TestModel", Price = 1111.22, YearModel=2003 }
            };
            _mockCarService.Setup(s => s.GetAllCarsOrderedByDateAsync()).ReturnsAsync(mockData);

            var contentResult = await _carController.Get() as OkObjectResult;
            var cars = contentResult?.Value as IList<CarDTO>;

            Assert.Equal(StatusCodes.Status200OK, contentResult.StatusCode);
            Assert.NotNull(cars);
            Assert.Equal(mockData.Count, cars.Count);
        }

        [Fact]
        public async Task GetCars_WhenExceptionWhileGettingCars_ReturnInternalServerError()
        {
            var exceptionMessage = "Exception while getting cars";
            _mockCarService.Setup(s => s.GetAllCarsOrderedByDateAsync()).Throws(new Exception(exceptionMessage));

            var contentResult = await _carController.Get() as ObjectResult;

            Assert.Equal(StatusCodes.Status500InternalServerError, contentResult.StatusCode);
            Assert.Equal(exceptionMessage, contentResult.Value?.ToString());
        }

        [Fact]
        public async Task GetCarById_WhenExistsNoExceptions_ReturnOkResultWithTheValidCar()
        {
            var carId = 1;
            var carDetails = new CarDetailsDTO();
            _mockCarService.Setup(s => s.GetCarDetailsAsync(carId)).ReturnsAsync(carDetails);

            var contentResult = await _carController.Get(carId) as OkObjectResult;
            var resultCarDetails = contentResult?.Value as CarDetailsDTO;

            Assert.Equal(StatusCodes.Status200OK, contentResult.StatusCode);
            Assert.NotNull(resultCarDetails);
            Assert.Equal(carDetails, resultCarDetails);
        }

        [Fact]
        public async Task GetCarById_WhenNotExists_ReturnNotFoundResult()
        {
            var carId = 1;
            _mockCarService.Setup(s => s.GetCarDetailsAsync(carId)).Throws(new ResourceNotFoundException());

            var contentResult = await _carController.Get(carId) as NotFoundResult;
 
            Assert.Equal(StatusCodes.Status404NotFound, contentResult.StatusCode);
        }

        [Fact]
        public async Task GetCars_WhenExceptionWhileGettingCarById_ReturnInternalServerError()
        {
            var carId = 1;
            var exceptionMessage = "Exception while getting car by Id";
            _mockCarService.Setup(s => s.GetCarDetailsAsync(carId)).Throws(new Exception(exceptionMessage));

            var contentResult = await _carController.Get(carId) as ObjectResult;

            Assert.Equal(StatusCodes.Status500InternalServerError, contentResult.StatusCode);
            Assert.Equal(exceptionMessage, contentResult.Value?.ToString());
        }
    }
}
