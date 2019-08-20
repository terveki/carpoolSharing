using System;
using System.Collections.Generic;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Dtos
{
    public class RideForUpdateDto
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int CarId { get; set; }

    }
}