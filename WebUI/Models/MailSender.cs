using System.Net;
using System.Net.Mail;

namespace WebUI.Models
{
    public static class MailSender
    {
        private const string systemEmail = "service@barsu.by";

        public static void SendMessage(string emailTo, string fullname, string message)
        {
            MailAddress from = new MailAddress(systemEmail, "АИС ServiceDesk");
            MailAddress to = new MailAddress(emailTo);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = $"{fullname} оставил сообщение.";
            msg.Body = message;
            msg.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("mail.barsu.by", 587);
            smtp.Credentials = new NetworkCredential(systemEmail,"d8wiPJjLXVIm");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }

        public static void SendFeedback(string name, string message)
        {
            MailAddress from = new MailAddress(systemEmail, name);
            MailAddress to = new MailAddress(systemEmail);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = $"Форма обратной связи. {name} оставил сообщение.";
            msg.Body = message;
            msg.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("mail.barsu.by", 587);
            smtp.Credentials = new NetworkCredential(systemEmail, "d8wiPJjLXVIm");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}