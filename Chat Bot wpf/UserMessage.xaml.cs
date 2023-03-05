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
    /// Interaction logic for UserMessage.xaml
    /// </summary>
    public partial class UserMessage : UserControl
    {
        public EventHandler<EventArgs> sendClicked { get; set; }


        public UserMessage()
        {
            InitializeComponent();
            sendClicked = new EventHandler<EventArgs>(SendClic);
        }

        private void SendClic(object sender, EventArgs e)
        {
            sendClicked.Invoke(this, EventArgs.Empty);
        }

        public string Message
        {
            get { return messageLbl.Content.ToString(); }
            set { messageLbl.Content = value; }
        }
    }
}
