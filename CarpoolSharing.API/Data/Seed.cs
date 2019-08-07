using System.Collections.Generic;
using CarpoolSharing.API.Models;
using Newtonsoft.Json;

namespace CarpoolSharing.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;

        }

        public void SeedUsers()
        {
            var employeeData = System.IO.File.ReadAllText("Data/EmployeeSeedData.json");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData);

            foreach (var employee in employees)
            {
                _context.Employees.Add(employee);
            }

            var carData = System.IO.File.ReadAllText("Data/CarSeedData.json");
            var cars = JsonConvert.DeserializeObject<List<Car>>(carData);

            foreach (var car in cars)
            {
                _context.Cars.Add(car);
            }

            _context.SaveChanges();
        }
    }
}