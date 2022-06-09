using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class CityDict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCityDict { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
