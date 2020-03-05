namespace Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InventoryNumber { get; set; }

        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
