using System;
using System.Collections.Generic;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class LettersManager : DataManager<Letter>
    {
        private readonly IStore<Letter> _lettersStore;

        public LettersManager(IStore<Letter> lettersStore) => _lettersStore = lettersStore;

        public override IEnumerable<Letter> Read() => _lettersStore?.Items;

        public override void Add(Letter item) => throw new NotImplementedException();

        public override void Update(Letter item) => throw new NotImplementedException();

        public override void Delete(Letter item) => throw new NotImplementedException();
    }
}
