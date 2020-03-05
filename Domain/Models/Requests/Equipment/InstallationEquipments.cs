namespace Domain.Models.Requests.Equipment
{
    public class InstallationEquipments
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int RequestId { get; set; }
        public EquipmentInstallationRequest Request { get; set; }
        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
