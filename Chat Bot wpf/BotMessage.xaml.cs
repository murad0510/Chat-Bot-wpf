using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat_Bot_wpf
{
    /// <summary>
    /// Interaction logic for BotMessage.xaml
    /// </summary>
    public partial class BotMessage : UserControl
    {
        public BotMessage()
        {
            InitializeComponent();
        }
        public string BotMessag
        {
            get { return Message.Content.ToString(); }
            set { Message.Content = value; }
        }


        public string DateMessage
        {
            get { return DateTimeLbl.Content.ToString(); }
            set { DateTimeLbl.Content = value; }
        }


    }
}
