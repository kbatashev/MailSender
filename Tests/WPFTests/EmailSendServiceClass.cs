using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
    public static class EmailSendServiceClass
    {
        public static void SendMail(string from, string to, string subject, string body, MailServerInfo server, string username, SecureString password)
        {
            using (var msg = new MailMessage(from, to, subject, body) { IsBodyHtml = false })
            {
                using (var client = new SmtpClient(server.HostName, server.Port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(username, password);
                    client.Send(msg);
                }
            }
        }
    }
}
