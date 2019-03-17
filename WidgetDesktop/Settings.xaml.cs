using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            getHDDs();
            getSettings();
        }

        private void getHDDs() {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string HDDSetting = WidgetDesktop.Properties.Settings.Default.HDDs_to_Monitor;

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady && drive.DriveType != DriveType.CDRom)
                {
                    clb_HDDS.Items.Add(drive.Name);
                }
            }
            //Activate HDD Checks
            clb_HDDS.SelectedItemsOverride = HDDSetting.Split(',').ToList();

            //Adjust Padding On Options Stack Panel
            int num = DO_StackPanel.Children.Count;
            int padding = 100 / (num + 2);
            GroupBox Parent = (GroupBox)DO_StackPanel.Parent;
            Parent.Padding = new Thickness(0,padding,0,padding);
        }
        private void getSettings()
        {
            if (chk_LMW.IsChecked == true)
                dud_MemVal.IsEnabled = true;


            //Adjust Color Settings Padding
            int count = Color_Stack.Children.Count;
            int padding = 100 / (count + 2);
            GroupBox Parent = (GroupBox)Color_Stack.Parent;
            Parent.Padding = new Thickness(0, padding, 0, padding);
            UIElementCollection Children = Color_Stack.Children;
            for (var i = 0; i < Children.Count; i++)
            {
                RadioButton child = (RadioButton)Children[i];
                if (i == Children.Count - 1 )
                {
                    child.Padding = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    child.Padding = new Thickness(0, 0, 0, padding);
                }
            }
        }
        private void saveHDDSettings()
        {
            List<string> hddlist = (List<string>)clb_HDDS.SelectedItems;
            string delimstring = string.Join(",", hddlist);
            WidgetDesktop.Properties.Settings.Default.HDDs_to_Monitor = delimstring;

            if (LDS_Warn.IsChecked == true)
                WidgetDesktop.Properties.Settings.Default.LDS_Warn = true;
            if (HDU_Warn.IsChecked == true)
                WidgetDesktop.Properties.Settings.Default.HDU_Warn = true;
            if (DOS_Act.IsChecked == true)
                WidgetDesktop.Properties.Settings.Default.DOS_Act = true;
            if (SID_Act.IsChecked == true)
                WidgetDesktop.Properties.Settings.Default.AOT_Act = true;
        }
        private void HDDOrientation_Checked(object sender, RoutedEventArgs e)
        {
            if (rad_HDD_OrientationH.IsChecked == true)
            {
                Properties.Settings.Default.HDDs_Orientation = 0;
            }
            else
            {
                Properties.Settings.Default.HDDs_Orientation = 1;
            }
        }
        private void saveMemSettings()
        {
            double mempercentage = dud_MemVal.Value.Value;
            WidgetDesktop.Properties.Settings.Default.MemPercentage = mempercentage;
            if (chk_LMW.IsChecked == true)
                WidgetDesktop.Properties.Settings.Default.WarnMem = true;
            else
                WidgetDesktop.Properties.Settings.Default.WarnMem = false;
        }
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (chk_LMW.IsChecked == true)
            {
                dud_MemVal.IsEnabled = true;
                WidgetDesktop.Properties.Settings.Default.WarnMem = true;
            }
            else
            {
                dud_MemVal.IsEnabled = false;
                WidgetDesktop.Properties.Settings.Default.WarnMem = false;
            }
        }
        private void dud_MemVal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            WidgetDesktop.Properties.Settings.Default.MemPercentage = dud_MemVal.Value.Value;
        }
        private void ColorPick_Selected(object sender, RoutedEventArgs e)
        {
            string source = e.Source.ToString().Substring(e.Source.ToString().IndexOf("Content:")+8, 4);
            switch (source)
            {
                case "Main":

                    
                    break;
                case "Hard":

                    break;
                case "Memo":

                    break;
            }
        }
        private void saveSettings_Click(object sender, RoutedEventArgs e)
        {
            //Save Monitor HDDs
            saveHDDSettings();
            saveMemSettings();
            Close();            
        }







    }
}
