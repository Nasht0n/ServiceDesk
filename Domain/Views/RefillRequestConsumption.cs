using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Views
{
    [Table("ConsumptionRefillRequestView")]
    public class RefillRequestConsumption
    {
        public string InventoryNumber { get; set; }
        public string Consumable { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }
    }
}
