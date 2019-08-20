using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Data
{
    public interface IEmployeeRideRepository
    {
        Task<EmployeeRide> Add(EmployeeRide employeeRide);
        Task<IEnumerable<EmployeeRide>> GetEmployeeRideByIds(int employee, int ride);
        Task<IEnumerable<EmployeeRide>> GetEmployeeRideByRideId(int ride);
        Task<bool> SaveAll();
        void Delete<T>(T entity) where T: class;
    }
}