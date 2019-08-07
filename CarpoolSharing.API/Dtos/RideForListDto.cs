using System;
using System.Collections.Generic;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Dtos
{
    public class RideForListDto
    {
        public int RideId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        public ICollection<EmployeeForListDto> Employee { get; set; }

        public string CarPlates { get; set; }
    }
}