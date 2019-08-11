using System.Linq;
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
        public DbSet<EmployeeRide> EmployeeRide {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRide>()
                .HasKey(er => new {  er.EmployeeId, er.RideId });

                var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetForeignKeys())
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                foreach (var fk in cascadeFKs)
                    fk.DeleteBehavior = DeleteBehavior.Restrict;

                base.OnModelCreating(modelBuilder);
        }
    }
}