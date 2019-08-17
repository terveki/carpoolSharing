using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Data
{
    public interface ICarsRepository
    {
        void Add<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Car>> GetCars();
         Task<Car> GetCar(int id);

         Task<IEnumerable<Car>> GetAvailableCars(RideForSearchDto rideForSearchDto);
         Task<IEnumerable<UtilizationPerYear>> GetCarStatistics(int id);
    }
}