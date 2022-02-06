using Garage.Business.CustomExceptions;
using Garage.Business.Infrastructure.DTOs;
using Garage.Business.Infrastructure.Iservices;
using Garage.DAL.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                // we may need to add pagination in the future 
                var cars = await _carService.GetAllCarsOrderedByDateAsync();

                return Ok(cars);
            }catch (Exception ex)
            {
                // TODO replace exception handling by exception middleware 
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var car = await _carService.GetCarDetailsAsync(id);
                return Ok(car);
            }
            catch(ResourceNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                // TODO replace exception handling by exception middleware 
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
