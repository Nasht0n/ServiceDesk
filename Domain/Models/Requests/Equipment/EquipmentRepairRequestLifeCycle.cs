using Domain.Abstract;

namespace Domain.Models.Requests.Equipment
{
    public class EquipmentRepairRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public EquipmentRepairRequest Request { get; set; }
    }
}
