using System;
using System.Threading.Tasks;
using Test2.Models;

namespace TestExample.Interfaces
{
    public interface IFlightServices
    {
        public Task<object> GetFlightInfo(string cityName);
        public Task<int> AddNewFlight(Flight flight, Plane plane);
    }
}
