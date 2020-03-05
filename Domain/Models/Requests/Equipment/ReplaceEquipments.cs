namespace Domain.Models.Requests.Equipment
{
    public class ReplaceEquipments
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public int RequestId { get; set; }
        public EquipmentReplaceRequest Request { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
