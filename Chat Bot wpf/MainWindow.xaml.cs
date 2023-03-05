using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using AIMLbot;

namespace Chat_Bot_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (messageTxtBox.Text == "Type a message")
            {
                messageTxtBox.Text = string.Empty;
            }
        }

        UserMessage userMessage;
        BotMessage botMessage;
        static int y = 10;
        static int x = 10;
        private void sendMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (messageTxtBox.Text.Trim() != string.Empty && messageTxtBox.Text != "Type a message")
            {
                userMessage = new UserMessage();
                userMessage.Message = messageTxtBox.Text;
                y += 25;
                messageTxtBox.Text = String.Empty;
                userMessage.Margin = new Thickness(0, y, 0, 0);
                myStackPanel.Children.Add(userMessage);

                Bot bot = new Bot();
                botMessage = new BotMessage();
                bot.loadSettings();
                bot.loadAIMLFromFiles();
                bot.isAcceptingUserInput = false;
                User user = new User("Username here", bot);
                bot.isAcceptingUserInput = true;
                x+= 10;
                Request request = new Request(userMessage.Message, user, bot);
                Result result = bot.Chat(request);
                botMessage.BotMessag = result.Output;
                botMessage.Margin = new Thickness(0, x, 0, 0);
                myStackPanel.Children.Add(botMessage);
            }
            else
            {
                System.Windows.MessageBox.Show("Not empty send comment!!!");
            }


        }
    }
}
