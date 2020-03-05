using System.Collections.Generic;

namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }

        public string Post { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool HeadOfUnit { get; set; }

        public int SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }

        public IList<Service> ApprovalServices { get; set; }
        public IList<ExecutorGroup> ExecutorGroups { get; set; }
        public IList<Subdivision> ExecutorSubdivisions { get; set; }
        public IList<Cabinet> Cabinets { get; set; }
    }
}