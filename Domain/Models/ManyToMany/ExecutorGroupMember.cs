namespace Domain.Models.ManyToMany
{
    public class ExecutorGroupMember
    {
        public int ExecutorGroupId { get; set; }
        public int EmployeeId { get; set; }

        public virtual ExecutorGroup ExecutorGroup { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
