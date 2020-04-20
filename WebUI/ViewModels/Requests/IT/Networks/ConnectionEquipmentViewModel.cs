using WebUI.ViewModels.EquipmentTypeModel;

namespace WebUI.ViewModels.Requests.IT.Networks
{
    public class ConnectionEquipmentViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int EquipmentTypeId { get; set; }
        public int RequestId { get; set; }
        public NetworkConnectionRequestViewModel RequestModel { get; set; }
        public EquipmentTypeViewModel EquipmentTypeModel { get; set; }
    }
}