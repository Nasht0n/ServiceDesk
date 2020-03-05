namespace Domain.Models.Requests.Network
{
    public class ConnectionEquipments
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }        
    }
}
