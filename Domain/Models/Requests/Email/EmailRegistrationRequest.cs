using Domain.Abstract;

namespace Domain.Models.Requests.Email
{
    public class EmailRegistrationRequest:Request
    {
        public string Email { get; set; }
    }
}
