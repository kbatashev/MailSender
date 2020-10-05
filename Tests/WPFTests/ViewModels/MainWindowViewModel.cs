using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MailSender.Lib.Entities;
using MailSender.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;


namespace MailSender.ViewModels
{
    
        public class MainWindowViewModel : ViewModelBase
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

            public ICommand SaveRecipientCommand { get; }
            public ICommand CreateRecipientCommand { get; }


            public MainWindowViewModel()
            {
                _serversManager = new ServersManager(new DebugServersStore());
                _sendersManager = new SendersManager(new DebugSendersStore());
                _recipientsManager = new RecipientsManager(new DebugRecipientsStore());
                _lettersManager = new LettersManager(new DebugLettersStore());

                Servers = new ObservableCollection<Server>(_serversManager.Read());
                Senders = new ObservableCollection<Sender>(_sendersManager.Read());
                Recipients = new ObservableCollection<Recipient>(_recipientsManager.Read());
                Letters = new ObservableCollection<Letter>(_lettersManager.Read());

                SelectedServer = _servers.FirstOrDefault();
                SelectedSender = _senders.FirstOrDefault();
                SelectedRecipient = _recipients.FirstOrDefault();
                SelectedLetter = _letters.FirstOrDefault();


                RefreshRecipientsCommand = new RelayCommand(
                    () => Recipients = new ObservableCollection<Recipient>(_recipientsManager.Read()),
                    () => true);

                SendMailCommand = new RelayCommand(
                    () => new DebugMailSender(SelectedServer).Send(SelectedLetter, SelectedSender.Address, SelectedRecipient.Address),
                    () => SelectedServer != null && SelectedLetter != null && SelectedSender != null && SelectedRecipient != null);

                SaveRecipientCommand = new RelayCommand(
                    () => _recipientsManager.Update(SelectedRecipient),
                    () => SelectedRecipient != null);

                CreateRecipientCommand = new RelayCommand(
                    () => _recipientsManager.Add(SelectedRecipient),
                    () => SelectedRecipient != null);
            }
        }
    }

