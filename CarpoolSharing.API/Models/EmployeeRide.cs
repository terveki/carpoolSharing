namespace CarpoolSharing.API.Models
{
    public class EmployeeRide
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int RideId { get; set; }
        public Ride Ride { get; set; }
    }
}