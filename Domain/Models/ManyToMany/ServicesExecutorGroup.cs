namespace Domain.Models.ManyToMany
{
    public class ServicesExecutorGroup
    {
        public int ServiceId { get; set; }
        public int ExecutorGroupId { get; set; }

        public virtual Service Service { get; set; }
        public virtual ExecutorGroup ExecutorGroup { get; set; }
    }
}
