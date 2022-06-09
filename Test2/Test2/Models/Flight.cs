using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFlight { get; set; }

        [Required]
        public DateTime FlightDate { get; set; }

        [MaxLength(200)]
        public string Comments { get; set; }

        public int IdPlane { get; set; }
        [ForeignKey("IdPlane")]
        public Plane Plane { get; set; }

        public int IdCityDict { get; set; }
        [ForeignKey("IdCityDict")]
        public CityDict CityDict { get; set; }
        ICollection<FlightPassanger> FlightPassangers { get; set; }
    }
}
