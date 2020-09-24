using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
    public sealed class EmailSendServiceClass
    {
        public void Send(string mailUser, SecureString mailPassword)
        {
            try
            {
                using (var message = new MailMessage(SendMailUserInfo.EmailFrom, SendMailUserInfo.EmailTo, SendMailUserInfo.EmailSubject, SendMailUserInfo.EmailBody))
                using (var client = new SmtpClient(SendMailUserInfo.Server)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(mailUser, mailPassword)
                })
                {
                    client.Send(message);
                }
            }
            catch(SmtpException error)
            {
                throw new SmtpException(error.Message);
            }
        }
    }
}
