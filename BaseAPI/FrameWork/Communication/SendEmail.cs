using FrameWork.Communication.Models.Email;
using System.Net.Mail;

namespace FrameWork.Communication
{
    public static class SendEmail
    {
         public static bool Send(EmailModel Mail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Mail.MailServer);

                mail.From = new MailAddress(Mail.From);
                mail.To.Add(Mail.To);
                mail.Subject = Mail.Subject;
                mail.Body = Mail.Body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Mail.UserName, Mail.Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
