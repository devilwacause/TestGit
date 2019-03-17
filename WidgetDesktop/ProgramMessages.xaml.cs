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
using System.Windows.Shapes;

namespace WidgetDesktop
{
    /// <summary>
    /// Interaction logic for ProgramMessages.xaml
    /// </summary>
    public partial class ProgramMessages : Window
    {
        public string MessageType;
        public ProgramMessages()
        {
            InitializeComponent();
        }
        public void SetMessage(string message) 
        {
            MessageValue.Text = message;
        }
        public void SetButtons(string okbtn_text, string cancelbtn_text)
        {
            okbtn.Text = okbtn_text;
            cancelbtn.Text = cancelbtn_text;
        }

        public void okbtn_onClick(object sender, EventArgs e)
        {
            this.Close();
            switch (MessageType)
            {
                case "LDU":
                    Properties.Settings.Default.LDUWarnMessage = false;
                    break;
            }
        }

        public void cancelbtn_onClick(object sender, EventArgs e)
        {
            this.Close();
            switch (MessageType)
            {
                case "LDU":
                    Properties.Settings.Default.LDUWarnMessage = true;
                    break;
            }
        }
    }
}
