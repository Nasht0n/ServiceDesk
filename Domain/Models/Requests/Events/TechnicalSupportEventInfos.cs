using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Events
{
    public class TechnicalSupportEventInfos
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }        
        [Required]
        public int CampusId { get; set; }        
        [Required]
        [MaxLength(150)]
        public string Location { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string StartTime { get; set; }
        [Required]
        [MaxLength(100)]
        public string EndTime { get; set; }

        public virtual TechnicalSupportEventRequest Request { get; set; }
        public virtual Campus Campus { get; set; }
    }
}
