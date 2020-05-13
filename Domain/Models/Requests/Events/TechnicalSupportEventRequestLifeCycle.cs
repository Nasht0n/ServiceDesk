using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Events
{
    public class TechnicalSupportEventRequestLifeCycle:LifeCycle
    {
        [Required]
        public int RequestId { get; set; }
        public TechnicalSupportEventRequest Request { get; set; }
    }
}
