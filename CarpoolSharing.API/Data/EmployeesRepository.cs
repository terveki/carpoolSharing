using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
             var employees = await _context.Employees.ToListAsync();

            return employees;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}