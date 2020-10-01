using System;
using System.Diagnostics;
using MailSender.Lib.Entities;

namespace MailSender.Services
{
    public class DebugMailSender
    {
        private readonly string _address;
        private readonly ushort _port;
        private readonly bool _useSsl;
        private readonly string _login;
        private readonly string _password;

        public DebugMailSender(string address, ushort port, bool useSsl, string login, string password)
        {
            _address = address;
            _port = port;
            _useSsl = useSsl;
            _login = login;
            _password = password;
        }

        public DebugMailSender(Server server)
        {
            _address = server.Address;
            _port = server.Port;
            _useSsl = server.UseSSL;
            _login = server.Login;
            _password = server.Password;
        }

        public void Send(string subject, string body, string from, string to)
        {
            Debug.WriteLine($"Sent from {from} to {to} via {_address}:{_port} ({(_useSsl ? "SSL" : "no SSL")})" +
                            $"{Environment.NewLine}Subject: {subject}" +
                            $"{Environment.NewLine}Body: {body}");
        }

        public void Send(Letter letter, string from, string to)
        {
            Debug.WriteLine($"Sent from {from} to {to} via {_address}:{_port} ({(_useSsl ? "SSL" : "no SSL")})" +
                            $"{Environment.NewLine}Subject: {letter.Subject}" +
                            $"{Environment.NewLine}Body: {letter.Body}");
        }
    }
}
