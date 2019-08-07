using System.Collections.Generic;

namespace CarpoolSharing.API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public bool IsDriver { get; set; }
        public ICollection<EmployeeRide> EmployeeRides { get; set; }
    }
}