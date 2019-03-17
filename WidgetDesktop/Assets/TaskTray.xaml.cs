using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WidgetDesktop.Assets
{
    /// <summary>
    /// Interaction logic for ResourceDictionary1.xaml
    /// </summary>
    public partial class TaskTray : Page
    {
    }

    public partial class TaskTrayMenu
    {
        
        private void contextSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings window = new Settings();
            window.Show();
        }

        private void contextHDD_Click(object sender, RoutedEventArgs e)
        {
            if (!Utils.IsWindowOpen<HDDs>())
            {
                HDDs hdd = new HDDs();
                hdd.Show();
            }
            else
            {
                Utils.ShowWindowOpen<HDDs>();
            }
        }

        private void contextRAM_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("RAM", "Message", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void Exit_app_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
