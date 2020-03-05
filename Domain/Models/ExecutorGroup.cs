using System.Collections.Generic;

namespace Domain.Models
{
    public class ExecutorGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Employee> Employees { get; set; }
        public IList<Service> Services { get; set; }
    }
}
