using System.Net;
using System.Net.Mail;

namespace WebUI.Models
{
    public static class MailSender
    {
        private const string systemEmail = "akorzun.91@gmail.com";

        public static void SendMessage(string emailTo, string fullname, string message)
        {
            MailAddress from = new MailAddress(systemEmail, "АИС ServiceDesk");
            MailAddress to = new MailAddress(emailTo);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = $"{fullname} оставил сообщение.";
            msg.Body = message;
            msg.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(systemEmail,"5893TohA0921");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}