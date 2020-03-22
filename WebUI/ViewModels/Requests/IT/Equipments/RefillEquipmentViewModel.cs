namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class RefillEquipmentViewModel
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public int RequestId { get; set; }
        public EquipmentRefillRequestViewModel RequestModel { get; set; }
    }
}