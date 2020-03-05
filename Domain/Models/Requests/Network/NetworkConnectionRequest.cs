using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Network
{
    public class NetworkConnectionRequest:Request
    {
        public string Location { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
        public IList<ConnectionEquipments> ConnectionEquipments { get; set; }
    }
}
