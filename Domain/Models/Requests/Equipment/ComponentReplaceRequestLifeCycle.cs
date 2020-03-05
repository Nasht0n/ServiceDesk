using Domain.Abstract;

namespace Domain.Models.Requests.Equipment
{
    public class ComponentReplaceRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public ComponentReplaceRequest Request { get; set; }
    }
}
