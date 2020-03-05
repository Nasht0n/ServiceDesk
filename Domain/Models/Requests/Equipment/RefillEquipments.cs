namespace Domain.Models.Requests.Equipment
{
    public class RefillEquipments
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }

        public int RequestId { get; set; }
        public EquipmentRefillRequest Request { get; set; }
    }
}
