using System;
using System.Collections.Generic;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Dtos
{
    public class RideForDetailedDto
    {
        public int RideId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<EmployeeForDetailedDto> Employees { get; set; }
        public CarForDetailedDto Car { get; set; }
    }
}