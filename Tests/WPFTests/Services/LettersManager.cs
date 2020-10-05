using System;
using System.Collections.Generic;
using MailSender.Lib.Entities;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class LettersManager : ILettersManager
    {
        private readonly IStore<Letter> _lettersStore;

        public LettersManager(IStore<Letter> lettersStore) => _lettersStore = lettersStore;

        public IEnumerable<Letter> Read() => _lettersStore?.GetItems();

        public void Add(Letter item) => throw new NotImplementedException();

        public void Update(Letter item) => throw new NotImplementedException();

        public void Delete(Letter item) => throw new NotImplementedException();
    }
}
