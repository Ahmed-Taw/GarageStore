using Garage.Business.Infrastructure.DTOs;
using Garage.Business.Infrastructure.Iservices;
using Garage.DAL.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public async Task<IEnumerable<CarDTO>> Get()
        {
            return await _carService.GetAllCarsOrderedByDateAsync();
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public async Task<CarDetailsDTO> Get(int id)
        {
            return await _carService.GetCarDetailsAsync(id);
        }
    }
}
