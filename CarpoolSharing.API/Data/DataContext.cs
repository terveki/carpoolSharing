using CarpoolSharing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Value> Values { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRide>()
                .HasKey(er => new {  er.EmployeeId, er.RideId });
        }
    }
}