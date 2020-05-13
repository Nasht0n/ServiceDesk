using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Events
{
    public class TechnicalSupportEventEquipments
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }        
        [Required]
        [MaxLength(150)]
        public string EquipmentName { get; set; }
        [Required]        
        public int Count { get; set; }

        public virtual TechnicalSupportEventRequest Request { get; set; }
    }
}
