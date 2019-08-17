using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Helpers;
using CarpoolSharing.API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ArrayHelper _arrays = new ArrayHelper();
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

        public async Task<IEnumerable<UtilizationPerYear>> GetCarStatistics(int id)
        {
            UtilizationPerYear[] result = _arrays.InitializeArray<UtilizationPerYear>(12);

            for (int month = 0; month <= 11; month++) {
                result[month].Month = month + 1;
            }

            var carId = new SqliteParameter("@carId", id);
            var rides = await _context.Rides.FromSql("SELECT * FROM 'Rides' WHERE Rides.CarId == @carId", carId).ToListAsync();

            foreach (var ride in rides)
            {
                DateTime day = ride.StartDate;

                var temp = day.CompareTo(ride.EndDate);
                while (temp != 0) {
                    result[day.Month - 1].NoOfDaysInUse ++;
                    day = day.AddDays(1);
                    temp = day.DayOfYear.CompareTo(ride.EndDate.DayOfYear);
                }
                result[day.Month - 1].NoOfDaysInUse ++;

            }

            return result;
        }

    }
}