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