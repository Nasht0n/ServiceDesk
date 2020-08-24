using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Views
{
    [Table("ConsumptionRefillRequestView")]
    public class RefillRequestConsumption
    {
        [Key]
        public long? Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Consumable { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }
        public int RequestNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string Subdivision { get; set; }
        public string Campus { get; set; }
        public string Location { get; set; }
        public string Fullname { get; set; }
    }
}
