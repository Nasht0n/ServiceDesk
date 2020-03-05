using Domain.Abstract;

namespace Domain.Models.Requests.Equipment
{
    public class EquipmentInstallationRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public EquipmentInstallationRequest Request { get; set; }
    }
}
