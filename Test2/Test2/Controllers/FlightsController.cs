using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Test2.Models;
using TestExample.Interfaces;

namespace TestExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        private readonly IFlightServices _service;

        public FlightsController(IFlightServices firefighterServices)
        {
            _service = firefighterServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetFireTruck([FromBody]  string cityName)
        {
            return Ok(await _service.GetFlightInfo(cityName));
        }

        [HttpPut("{IdAction}")]
        public async Task<IActionResult> UpdateEndDateOfFireFightAction([FromBody] Flight flight, [FromBody] Plane plane)
        {
            int result = await _service.AddNewFlight(flight, plane);
            if (result == 1)
            {
                return Ok("Succesfully updated end date");
            } else
            {
                return BadRequest("End date cannot be null or earlier then start date");
            }
            
        }
    }
}
