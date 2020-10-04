using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    public partial class MessageWindow : Window
    {
        public string Caption { get; set; }
        public string MessageText { get; set; }
        public Brush MessageBrush { get; set; }

        public static void Show(string caption, string messageText, Brush messageBrush)
        {
            new MessageWindow
            {
                Caption = caption,
                MessageText = messageText,
                MessageBrush = messageBrush
            }.ShowDialog();
        }

        public MessageWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
