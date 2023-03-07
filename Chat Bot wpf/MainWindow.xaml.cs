using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        static int y = 16;
        static int x = 16;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private void sendMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (messageTxtBox.Text.Trim() != string.Empty && messageTxtBox.Text != "Type a message")
            {
                userMessage = new UserMessage();
                userMessage.Message = messageTxtBox.Text;
                userMessage.Date = DateTime.Now.ToShortTimeString();
                y += 25;
                messageTxtBox.Text = String.Empty;
                userMessage.Margin = new Thickness(0, y, 0, 0);
                myStackPanel.Children.Add(userMessage);

                Timer(sender, e);

            }
            else
            {
                System.Windows.MessageBox.Show("Not empty send comment!!!");
            }
        }

        public void Timer(object sender, EventArgs e)
        {

            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        static int count = 3;
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (count != 0)
            {
                onlineLbl.Content = "Typing . . .";
                count -= 1;
            }
            else
            {
                dispatcherTimer.Stop();
                count = 3;
                onlineLbl.Content = "online";
                Bot bot = new Bot();
                botMessage = new BotMessage();
                bot.loadSettings();
                bot.loadAIMLFromFiles();
                bot.isAcceptingUserInput = false;
                User user = new User("Username here", bot);
                bot.isAcceptingUserInput = true;
                x += 10;
                Request request = new Request(userMessage.Message, user, bot);
                Result result = bot.Chat(request);
                botMessage.BotMessag = result.Output;
                botMessage.DateMessage = DateTime.Now.ToShortTimeString();
                botMessage.Margin = new Thickness(0, x, 0, 0);
                myStackPanel.Children.Add(botMessage);
            }
        }
    }
}
