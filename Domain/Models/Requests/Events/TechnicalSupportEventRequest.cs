using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Events
{
    public class TechnicalSupportEventRequest : Request
    {
        public virtual IList<TechnicalSupportEventInfos> EventInfos { get; set; }
        public virtual IList<TechnicalSupportEventEquipments> EventEquipments { get; set; }
    }
}
