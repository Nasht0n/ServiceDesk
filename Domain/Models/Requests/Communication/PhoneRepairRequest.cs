using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class PhoneRepairRequest:Request
    {
        public string Location { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
