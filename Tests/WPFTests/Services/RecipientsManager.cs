using System.Collections.Generic;
using System.Diagnostics;
using MailSender.Lib.Entities;
using MailSender.Interfaces;


namespace MailSender.Services
{
    public class RecipientsManager : IRecipientsManager
    {
        private readonly IStore<Recipient> _recipientsStore;

        public RecipientsManager(IStore<Recipient> recipientsStore) => _recipientsStore = recipientsStore;

        public IEnumerable<Recipient> Read() => _recipientsStore?.GetItems();

        public void Add(Recipient item) =>
            Debug.WriteLine($"RecipientsManager.Create Id = {item.Id}, Name = {item.Name}, Address = {item.Address}");

        public void Update(Recipient item) =>
            Debug.WriteLine($"RecipientsManager.Update Id = {item.Id}, Name = {item.Name}, Address = {item.Address}");

        public void Delete(Recipient item) =>
            Debug.WriteLine($"RecipientsManager.Delete Id = {item.Id}, Name = {item.Name}, Address = {item.Address}");

    }
}
