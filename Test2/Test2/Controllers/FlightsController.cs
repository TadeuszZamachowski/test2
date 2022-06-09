using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [HttpGet("{cityName?}")]
        public async Task<IActionResult> GetFlightInfo(string cityName)
        {
            
            return Ok(await _service.GetFlightInfo(cityName));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewFlight([FromBody] JObject data)
        {
            Flight flight = data["flightData"].ToObject<Flight>();
            Plane plane = data["planeData"].ToObject<Plane>();


            int result = await _service.AddNewFlight(flight, plane);
            if (result == 1)
            {
                return Ok("Flight added");
            } else
            {
                return BadRequest("Plane already assigned to flight");
            }
            
        }
    }
}
