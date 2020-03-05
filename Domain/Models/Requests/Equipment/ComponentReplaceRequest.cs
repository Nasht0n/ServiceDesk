using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Equipment
{
    public class ComponentReplaceRequest:Request
    {
        public string Location { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public IList<ReplaceComponents> ReplaceComponents { get; set; }
    }
}
