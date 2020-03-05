using Domain.Abstract;

namespace Domain.Models.Requests.Equipment
{
    public class EquipmentRefillRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public EquipmentRefillRequest Request { get; set; }
    }
}
