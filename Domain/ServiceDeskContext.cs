using Domain.Models;
using System.Data.Entity;

namespace Domain
{
    public class ServiceDeskContext:DbContext
    {
        public ServiceDeskContext() : base() { }

        public virtual DbSet<Branch> Brunches { get; set; }
        public virtual DbSet<Category> Categories { get; set; }        
        
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<RefuelingLimits> RefuelingLimits { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
