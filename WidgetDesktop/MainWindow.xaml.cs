using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Win32;
using System;
using System.Management;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
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

namespace WidgetDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            //initialize NotifyIcon
            tb = (TaskbarIcon)FindResource("MyNotifyIcon");
            //Initalize Drag Window Ability
            MouseDown += Window_MouseDown;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public TaskbarIcon tb { get; set; }
    }
}
