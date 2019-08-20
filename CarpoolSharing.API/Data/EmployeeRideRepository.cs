using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class EmployeeRideRepository : IEmployeeRideRepository
    {
        private readonly DataContext _context;

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


        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}