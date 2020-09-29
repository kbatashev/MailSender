using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace MailSender
{
    public class MailServerInfo
    {
        
    public string Name { get; }
    public string HostName { get; }
    public int Port { get; }
    public bool EnableSsl { get; set; }

    public static ObservableCollection<MailServerInfo> Servers { get; set; }

    public MailServerInfo(string name, string hostName, int port, bool enableSsl)
    {
        Name = name;
        HostName = hostName;
        Port = port;
        EnableSsl = enableSsl;
    }

    static MailServerInfo()
    {
        Servers = new ObservableCollection<MailServerInfo>
            {
                new MailServerInfo("Yandex", "smtp.yandex.ru", 25, true),
                new MailServerInfo("Mail.ru", "smtp.mail.ru", 25, true),
                new MailServerInfo("Google", "smtp.gmail.com", 465, true)
            };
    }
}
}
