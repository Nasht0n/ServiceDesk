namespace Domain.Models.Requests.Equipment
{
    public class RepairEquipments
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int RequestId { get; set; }
        public EquipmentRepairRequest Request { get; set; }
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
    }
}
