using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarpoolSharing.API.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Plates { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public int NoOfSeats { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}