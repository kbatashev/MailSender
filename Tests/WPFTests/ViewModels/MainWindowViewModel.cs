using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MailSender.Lib.Entities;
using MailSender.MVVM;
using MailSender.Services;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly ServersManager _serversManager;
        private readonly SendersManager _sendersManager;
        private readonly RecipientsManager _recipientsManager;
        private readonly LettersManager _lettersManager;

        private ObservableCollection<Server> _servers;
        private ObservableCollection<Sender> _senders;
        private ObservableCollection<Recipient> _recipients;
        private ObservableCollection<Letter> _letters;

        private Server _selectedServer;
        private Sender _selectedSender;
        private Recipient _selectedRecipient;
        private Letter _selectedLetter;

        public ObservableCollection<Server> Servers
        {
            get => _servers;
            private set => Set(ref _servers, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _senders;
            private set => Set(ref _senders, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _recipients;
            private set => Set(ref _recipients, value);
        }

        public ObservableCollection<Letter> Letters
        {
            get => _letters;
            private set => Set(ref _letters, value);
        }


        public Server SelectedServer
        {
            get => _selectedServer;
            set => Set(ref _selectedServer, value);
        }

        public Sender SelectedSender
        {
            get => _selectedSender;
            set => Set(ref _selectedSender, value);
        }

        public Recipient SelectedRecipient
        {
            get => _selectedRecipient;
            set => Set(ref _selectedRecipient, value);
        }

        public Letter SelectedLetter
        {
            get => _selectedLetter;
            set => Set(ref _selectedLetter, value);
        }

        public ICommand RefreshRecipientsCommand { get; }

        public ICommand SendMailCommand { get; }


        public MainWindowViewModel()
        {
            _serversManager = new ServersManager(new DebugServersStore());
            _sendersManager = new SendersManager(new DebugSendersStore());
            _recipientsManager = new RecipientsManager(new DebugRecipientsStore());
            _lettersManager = new LettersManager(new DebugLettersStore());

            _servers = new ObservableCollection<Server>(_serversManager.Read());
            _senders = new ObservableCollection<Sender>(_sendersManager.Read());
            _recipients = new ObservableCollection<Recipient>(_recipientsManager.Read());
            _letters = new ObservableCollection<Letter>(_lettersManager.Read());

            SelectedServer = _servers.FirstOrDefault();
            SelectedSender = _senders.FirstOrDefault();
            SelectedRecipient = _recipients.FirstOrDefault();
            _selectedLetter = _letters.FirstOrDefault();


            RefreshRecipientsCommand = new Command(RefreshRecipientsCommandAction);

            SendMailCommand = new Command(SendMailCommandAction);
        }

        private void RefreshRecipientsCommandAction(object o)
        {
            _recipients = new ObservableCollection<Recipient>(_recipientsManager.Read());
        }

        private void SendMailCommandAction(object obj)
        {
            new DebugMailSender(SelectedServer)
                .Send(SelectedLetter, _selectedSender.Address, SelectedRecipient.Address);
        }
    }
}
