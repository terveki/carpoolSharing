using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class CarsRepository : ICarsRepository
    {
        private readonly DataContext _context;

        public CarsRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<IEnumerable<Car>> GetAvailableCars(RideForSearchDto rideForSearchDto)
        {
            var startDate = new SqliteParameter("@startDate", rideForSearchDto.StartDate);
            var endDate = new SqliteParameter("@endDate", rideForSearchDto.EndDate);
            var cars = await _context.Cars.FromSql("SELECT Cars.* FROM Cars WHERE NOT EXISTS (SELECT Rides.RideId FROM Rides WHERE Rides.CarId = Cars.CarId AND ((Rides.StartDate <= @startDate AND Rides.EndDate >= @startDate) OR (Rides.StartDate >= @startDate AND Rides.StartDate <= @endDate)))", startDate, endDate).ToListAsync();
            return cars;
        }

        public async Task<Car> GetCar(int id)
        {
            var ride = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            return ride;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            var cars = await _context.Cars.ToListAsync();

            return cars;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}