using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class FlightPassanger
    {
        public int IdFlight { get; set; }
        [ForeignKey("IdFlight")]
        public Flight Flight { get; set; }

        public int IdPassanger { get; set; }
        [ForeignKey("IdPassanger")]
        public Passenger Passenger { get; set; }
    }
}
