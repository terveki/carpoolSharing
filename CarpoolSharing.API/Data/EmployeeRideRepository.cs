using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Helpers;
using CarpoolSharing.API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class EmployeeRideRepository : IEmployeeRideRepository
    {
        private readonly DataContext _context;
        private readonly ArrayHelper _arrays = new ArrayHelper();

        public EmployeeRideRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EmployeeRide> Add(EmployeeRide employeeRide)
        {
            await _context.EmployeeRide.AddAsync(employeeRide);

            return employeeRide;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<EmployeeRide>> GetEmployeeRideByIds(int employee, int ride)
        {
            var employeeId = new SqliteParameter("@employeeId", employee);
            var rideId = new SqliteParameter("@rideId", ride);
            var employeeRides = await _context.EmployeeRide.FromSql("SELECT * FROM EmployeeRide WHERE EmployeeRide.EmployeeId == @employeeId AND EmployeeRide.RideId == @rideId", employeeId, rideId).ToListAsync();

            return employeeRides;
        }

        public async Task<IEnumerable<EmployeeRide>> GetEmployeeRideByRideId(int ride)
        {
            var rideId = new SqliteParameter("@rideId", ride);
            var employeeRides = await _context.EmployeeRide.FromSql("SELECT * FROM EmployeeRide WHERE EmployeeRide.RideId == @rideId", rideId).ToListAsync();

            return employeeRides;
        }

        public async Task<IEnumerable<UtilizationPerMonth>> GetEmployeeStatsByMonth(int month)
        {
            int days = DateTime.DaysInMonth(2019, month);
            UtilizationPerMonth[] result = _arrays.InitializeArray<UtilizationPerMonth>(days);

            for (var day = 0; day < days; day ++) {
                result[day].Day = day + 1;
            }

            DateTime firstDayOfMonth = new DateTime(2019, month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var firstDay = new SqliteParameter("@firstDay", firstDayOfMonth);
            var lastDay = new SqliteParameter("@lastDay", lastDayOfMonth);
            var emplRides = await _context.EmployeeRide.FromSql("SELECT EmployeeRide.EmployeeId, EmployeeRide.RideId FROM EmployeeRide LEFT JOIN Rides ON Rides.RideId = EmployeeRide.RideId WHERE ((Rides.StartDate < @firstDay AND Rides.EndDate >= @firstDay) OR (Rides.StartDate >= @firstDay AND Rides.StartDate <= @lastDay))", firstDay, lastDay).ToListAsync();
            
            foreach (var emplRide in emplRides)
            {
                var theRide = await _context.Rides.FirstOrDefaultAsync(r => r.RideId == emplRide.RideId);
                DateTime day = theRide.StartDate;

                while (day <= theRide.EndDate)
                {
                    if (day.Month == month) {
                        result[day.Day - 1].NoOfItemsInUse ++;
                    }
                    day = day.AddDays(1);
                }
            }
            return result;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}