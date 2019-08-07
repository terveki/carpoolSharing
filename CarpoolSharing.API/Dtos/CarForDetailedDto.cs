namespace CarpoolSharing.API.Dtos
{
    public class CarForDetailedDto
    {
        public int CarId { get; set; }
        public string Plates { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public int NoOfSeats { get; set; }
    }
}