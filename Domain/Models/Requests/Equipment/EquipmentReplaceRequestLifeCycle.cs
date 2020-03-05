using Domain.Abstract;

namespace Domain.Models.Requests.Equipment
{
    public class EquipmentReplaceRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public EquipmentReplaceRequest Request { get; set; }
    }
}
