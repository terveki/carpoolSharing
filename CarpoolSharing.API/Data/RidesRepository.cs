using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Helpers;
using CarpoolSharing.API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class RidesRepository : IRidesRepository
    {
        private readonly ArrayHelper _arrays = new ArrayHelper();
        private readonly DataContext _context;

        public RidesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Ride> Add(Ride ride)
        {
            await _context.Rides.AddAsync(ride);
            await _context.SaveChangesAsync();

            return ride;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
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

        public async Task<Ride> GetRide(int id)
        {
            var ride = await _context.Rides.Include(c => c.Car)
                                           .Include(er => er.EmployeeRides).ThenInclude(e => e.Employee)
                                           .FirstOrDefaultAsync(r => r.RideId == id);
            
            return ride;
        }

        public async Task<IEnumerable<Ride>> GetRides()
        {
            var rides = await _context.Rides.Include(c => c.Car)
                                            .Include(er => er.EmployeeRides).ThenInclude(e => e.Employee).ToListAsync();

            return rides;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}