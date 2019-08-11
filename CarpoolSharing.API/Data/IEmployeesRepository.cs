using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Data
{
    public interface IEmployeesRepository
    {
        void Add<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);

        Task<IEnumerable<Employee>> GetAvailableEmployees(RideForSearchDto rideForSearchDto);
    }
}