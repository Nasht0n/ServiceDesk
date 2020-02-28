using Domain.Models;
using System.Data.Entity;

namespace Domain
{
    public class ServiceDeskContext:DbContext
    {
        public ServiceDeskContext() : base() { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brunch> Brunches { get; set; }
        public virtual DbSet<Service> Services { get; set; }
    }
}
