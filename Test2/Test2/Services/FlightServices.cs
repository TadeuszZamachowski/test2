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
            if (cityName == null)
            {
                var flights = from fp in _dbContext.FlightPassangers
                              join f in _dbContext.Flights on fp.IdFlight equals f.IdFlight
                              join p in _dbContext.Passengers on fp.IdPassanger equals p.IdPassanger
                              select new
                              {
                                  IdFlight = f.IdFlight,
                                  FlightDate = f.FlightDate,
                                  Comments = f.Comments,
                                  IdPlane = f.IdPlane,
                                  IdCity = f.IdCityDict,

                                  passengers = new Passenger
                                  {
                                      FirstName = p.FirstName,
                                      LastName = p.LastName
                                  }


                              };
                return flights;




            } else
            {
                var flights = from fp in _dbContext.FlightPassangers
                              join f in _dbContext.Flights on fp.IdFlight equals f.IdFlight
                              join p in _dbContext.Passengers on fp.IdPassanger equals p.IdPassanger
                              join c in _dbContext.CityDicts on f.IdCityDict equals c.IdCityDict
                              where c.City == cityName
                              select new
                              {
                                  IdFlight = f.IdFlight,
                                  FlightDate = f.FlightDate,
                                  Comments = f.Comments,
                                  IdPlane = f.IdPlane,
                                  IdCity = f.IdCityDict,

                                  passengers = new Passenger
                                  {
                                      FirstName = p.FirstName,
                                      LastName = p.LastName
                                  }
                              };
                return flights;
            }

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
