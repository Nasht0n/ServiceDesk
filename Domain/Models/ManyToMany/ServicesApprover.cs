namespace Domain.Models.ManyToMany
{
    public class ServicesApprover
    {
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
