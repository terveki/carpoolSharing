using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Models;
using Microsoft.Data.Sqlite;
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

        public async Task<IEnumerable<Employee>> GetAvailableEmployees(RideForSearchDto rideForSearchDto)
        {
            var startDate = new SqliteParameter("@startDate", rideForSearchDto.StartDate);
            var endDate = new SqliteParameter("@endDate", rideForSearchDto.EndDate);

            // get all employees
             var employees = await _context.Employees.FromSql("SELECT * FROM Employees").ToListAsync();
            // get employees whose rides are in given time interval
            var employeesRideOccupied = await _context.EmployeeRide.FromSql("SELECT EmployeeRide.EmployeeId, EmployeeRide.RideId FROM EmployeeRide LEFT JOIN Rides ON Rides.RideId = EmployeeRide.RideId WHERE ( Rides.RideId = EmployeeRide.RideId AND ((Rides.StartDate <= @startDate AND Rides.EndDate >= @startDate) OR (Rides.StartDate >= @startDate AND Rides.StartDate <= @endDate)))", startDate, endDate).ToListAsync();

            foreach (EmployeeRide employeeRide in employeesRideOccupied)
            {
                Employee employee = await GetEmployee(employeeRide.EmployeeId);
                employees.Remove(employee);
            }

            return employees;
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