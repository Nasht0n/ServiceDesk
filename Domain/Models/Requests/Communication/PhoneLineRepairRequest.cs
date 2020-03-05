using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class PhoneLineRepairRequest:Request
    {
        public string Location { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
