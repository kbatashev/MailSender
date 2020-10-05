using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSender.Interfaces;
using MailSender.Services;
using MailSender.ViewModels;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
     
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IServersStore, DebugServersStore>();
            SimpleIoc.Default.Register<ILettersStore, DebugLettersStore>();
            SimpleIoc.Default.Register<ISendersStore, DebugSendersStore>();
            SimpleIoc.Default.Register<IRecipientsStore, DebugRecipientsStore>();

            SimpleIoc.Default.Register<IServersManager, ServersManager>();
            SimpleIoc.Default.Register<ILettersManager, LettersManager>();
            SimpleIoc.Default.Register<ISendersManager, SendersManager>();
            SimpleIoc.Default.Register<IRecipientsManager, RecipientsManager>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
