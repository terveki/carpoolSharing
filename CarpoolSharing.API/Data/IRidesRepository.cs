using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Data
{
    public interface IRidesRepository
    {
        Task<Ride> Add(Ride ride);
        Task<bool> SaveAll();
        Task<IEnumerable<Ride>> GetRides();
        Task<Ride> GetRide(int id);
        void Delete<T>(T entity) where T: class;
    }
}