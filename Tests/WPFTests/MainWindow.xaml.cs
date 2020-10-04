﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Media;
using MailSender.Lib;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;

namespace MailSender
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSend_OnClick(object sender, RoutedEventArgs e)
        {
            var mailSender = CbSenders.SelectedValue as Sender;
            if (mailSender == null) throw new ArgumentNullException(nameof(mailSender));

            var server = CbServers.SelectedValue as Server;
            if (server == null) throw new ArgumentNullException(nameof(server));

            var recipient = DgRecipients.SelectedValue as Recipient;
            if (recipient == null) throw new ArgumentNullException(nameof(recipient));

            new Lib.DebugMailSender(server).Send(TbMessageSubject.Text, TbMessageText.Text, mailSender.Address, recipient.Address);
        }

        private void ButtonEditSender_OnClick(object sender, RoutedEventArgs e)
        {
            var mailSender = CbSenders.SelectedValue as Sender;
            if (mailSender == null) throw new ArgumentNullException(nameof(mailSender));

            var dialog = new EditSenderWindow { DataContext = mailSender.Clone() as Sender };
            if (dialog.ShowDialog() != true)
                return;

            var index = TestData.Senders.IndexOf(mailSender);
            TestData.Senders.RemoveAt(index);
            TestData.Senders.Insert(index, dialog.DataContext as Sender);
            CbSenders.SelectedIndex = index;
        }
    }
}
