using System.Threading.Tasks;
using TestExample.Interfaces;
using TestExample.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Test2.Models;

namespace TestExample.Services
{
    public class FlightServices : IFlightServices
    {

        private readonly FlightsDbContext _dbContext;

        public FlightServices(FlightsDbContext flightsContext)
        {
            _dbContext = flightsContext;
        }

        public async Task<object> GetFlightInfo(string cityName)
        {
           // var truck = await _dbContext.FireTrucks.Where(x => x.IdFireTruck == IdFireTruck)
           //                             .Include(x => x.FireTruckActions)
           //                             .ThenInclude(x => x.Action)   
           //                             .ThenInclude(x => x.FirefighterActions)
           //                             .ThenInclude(x => x.Firefighter)
            //                            .OrderByDescending(x => x.IdFireTruck)
            //                            .FirstAsync();

            
            //var flights = await _dbContext.Flights
            return null;
        }

        public async Task<int> AddNewFlight(Flight flight, Plane plane)
        {

            var exists = _dbContext.Planes.Where(x => x.IdPlane == plane.IdPlane).Count();
            if (exists > 0)
            {
                var planeAlreadyAssigned = _dbContext.Flights.Where(x => x.IdPlane == plane.IdPlane &&
                                                    DateTime.Compare(x.FlightDate, flight.FlightDate) == 0)
                                                    .Count();
                if (planeAlreadyAssigned > 0)
                {
                    return -1;
                }
               
            }
                                                          
                    _dbContext.Planes.Add(plane);
                    flight.IdPlane = plane.IdPlane;
                    _dbContext.Flights.Add(flight);

                    await _dbContext.SaveChangesAsync();

                    return 1;                         
        }



    }
}
