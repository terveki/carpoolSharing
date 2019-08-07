using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Data
{
    public interface IRidesRepository
    {
        void Add<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Ride>> GetRides();
         Task<Ride> GetRide(int id);
    }
}