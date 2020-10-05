using MailSender.Interfaces;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;


namespace MailSender.Services
{
    public class DebugServersStore : DebugStore<Server>, IServersStore
    {
        public DebugServersStore() : base(TestData.Servers)
        {

        }

        public override void Update(int id, Server server)
        {
            var dbSerber = GetById(id);
            if (dbSerber == null)
                return;

            dbSerber.Name = server.Name;
            dbSerber.Address = server.Address;
            dbSerber.Port = server.Port;
            dbSerber.UseSSL = server.UseSSL;
            dbSerber.Login = server.Login;
            dbSerber.Password = server.Password;
        }
    }
}
