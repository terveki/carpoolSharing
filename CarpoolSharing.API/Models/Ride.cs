using System;
using System.Collections.Generic;

namespace CarpoolSharing.API.Models
{
    public class Ride
    {
        public int RideId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<EmployeeRide> EmployeeRides { get; set; }

    }
}