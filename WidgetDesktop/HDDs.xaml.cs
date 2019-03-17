using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Diagnostics;
using System.Threading;


namespace WidgetDesktop
{
    /// <summary>
    /// Interaction logic for HDDs.xaml
    /// </summary>
    public partial class HDDs : Window
    {
        //Global Class Variables
        System.Timers.Timer checkHddValues = new System.Timers.Timer();
        System.Timers.Timer checkDiskUsage = new System.Timers.Timer();
        private double HDU_Count = 0;
        private int run_count = 1;
        private int drive_count;
        private string val_at_load;
        private int orientation_at_load;
        List<string> loaded_hdds = new List<string>();
        List<Grid> Grids = new List<Grid>();

        public class HDDs_Cap : IEnumerable<HDDInfo>
        {
            public List<HDDInfo> drives = new List<HDDInfo>();

            public IEnumerator<HDDInfo> GetEnumerator()
            {
                return drives.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return drives.GetEnumerator();
            }
        }
        public class HDDInfo
        {
            public string drive_name;
            public long space;
            public long used;
            public DriveType type = new DriveType();
            public bool update_pie = false;
        }

        public class HDDSize
        {
            public double size;
            public string post;
        }

        public HDDs_Cap DisplayedHDDs = new HDDs_Cap();

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }


        public HDDs()
        {
            this.Top = Properties.Settings.Default.HDDs_Top;
            this.Left = Properties.Settings.Default.HDDs_Left;
            InitializeComponent();
            this.Background.Opacity = .5;
            val_at_load = Properties.Settings.Default.HDDs_to_Monitor;
            orientation_at_load = Properties.Settings.Default.HDDs_Orientation;
            Properties.Settings.Default.SettingChanging += SettingChanging;
            checkHddValues.Enabled = true;
            checkHddValues.Interval = 5000;
            checkHddValues.Elapsed += checkValues_Elapsed;
            checkDiskUsage.Interval = 1000;
            checkDiskUsage.Enabled = false;
            checkDiskUsage.Elapsed += checkDiskUsage_Elapsed;
            AddTopButtons();
            AddGrids(val_at_load);
            //CreateHDDViews(val_at_load);
            MouseDown += Window_MouseDown;
            
        }
        void checkDiskUsage_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            Task CheckValue = new Task(du);
            CheckValue.Start();
            
        }
        private void du()
        {

            PerformanceCounter pc = new PerformanceCounter("PhysicalDisk", "% Idle Time", "_Total", true);
            pc.NextValue(); //Call once to initialize
            Thread.Sleep(30000);
            double value = Convert.ToDouble(pc.NextValue());// *100;
            HDU_Count += value;
            
            if (run_count >= 9)
            {
                run_count = 0;
                double final = HDU_Count / 10;
                Console.WriteLine("FINAL HDU % " + (100-final));
                HDU_Count = 0;
            }
            else
            {
                run_count++;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Hdds_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.HDDs_Top = (int)this.Top;
            Properties.Settings.Default.HDDs_Left = (int)this.Left;
        }
        private void Hdds_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background.Opacity = 1;
        }

        private void Hdds_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background.Opacity = .5;
        }

        void checkValues_Elapsed(object sender, ElapsedEventArgs e)
        {
            AddGrids(val_at_load);
        }

        private void SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (e.SettingName == "HDDs_to_Monitor")
            {
                if (e.NewValue != val_at_load)
                {
                    //Reset the view to show the selected drives
                    val_at_load = e.NewValue.ToString();
                    AddGrids(e.NewValue.ToString());
                }
            }
            else if (e.SettingName == "HDDs_Orientation")
            {
                if ((int)e.NewValue != orientation_at_load)
                {
                    int newVal = (int)e.NewValue;
                    if (newVal == 0)
                    {
                        HDD_Stack.Orientation = Orientation.Horizontal;
                        Console.WriteLine("HDD Stack Orientation = Horizontal");
                    }
                    else
                    {
                        HDD_Stack.Orientation = Orientation.Vertical;
                        Console.WriteLine("HDD Stack Orientation = Vertical");
                    }
                    orientation_at_load = (int)e.NewValue;
                }
            }
        }

        private void AddTopButtons()
        {
            Button exit = new Button();
            Button AOT = new Button();
            exit.Content = "X";
            exit.Background = Brushes.Red;
            exit.Foreground = Brushes.White;
            AOT.Content = "^";
            AOT.Background = Brushes.Blue;
            AOT.Foreground = (Brush)this.Resources["ControlTextBrush"];
            exit.SetValue(Grid.RowProperty, 0);
            exit.Width = 25;
            exit.Height = 25;
            exit.HorizontalAlignment = HorizontalAlignment.Right;
            exit.Click += exit_Click;
            AOT.SetValue(Grid.RowProperty, 0);
            AOT.Width = 25;
            AOT.Height = 25;
            Grid topLevel = (Grid)HDD_Stack.Parent;
            topLevel.Children.Add(exit);
            topLevel.Children.Add(AOT);
        }

        void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddGrids(string HDD_list)
        {
            List<string> sel_drives = HDD_list.Split(',').ToList();
            if(loaded_hdds.Count < 1) {
                loaded_hdds = sel_drives;
            }else if(loaded_hdds.Count != sel_drives.Count) {
                loaded_hdds = sel_drives;
            }
            
            drive_count = loaded_hdds.Count;
            int Current_Grids;
            this.Dispatcher.Invoke(() =>
            {
                Current_Grids = HDD_Stack.Children.OfType<Grid>().Count<Grid>();
                if (Current_Grids != drive_count)
                {
                    HDD_Stack.Children.Clear();
                    Grids.Clear();
                    for (int i = 0; i < drive_count; i++)
                    {
                        Grid newGrid = new Grid();
                        ColumnDefinition pieArea = new ColumnDefinition();
                        pieArea.Width = new GridLength(45, GridUnitType.Star);
                        ColumnDefinition infoArea = new ColumnDefinition();
                        infoArea.Width = new GridLength(50, GridUnitType.Star);
                        newGrid.ColumnDefinitions.Add(pieArea);
                        newGrid.ColumnDefinitions.Add(infoArea);
                        newGrid.Name = sel_drives[i].TrimEnd('\\').TrimEnd(':');
                        newGrid.Height = 100;
                        newGrid.Width = 220;
                        Grids.Add(newGrid);
                        HDD_Stack.Children.Add(newGrid);
                    }
                }
                AddTextInfo(HDD_list);
            });
             
            
            
        }

        private void AddTextInfo(string HDD_list)
        {
            List<string> sel_drives = HDD_list.Split(',').ToList();
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo d in drives)
            {
                if (sel_drives.Contains(d.Name))
                {
                    HDDInfo info = new HDDInfo();
                    info.drive_name = d.Name;
                    info.type = d.DriveType;
                    info.used = d.TotalSize - d.AvailableFreeSpace;
                    info.space = d.AvailableFreeSpace;
                    string childn = d.Name.TrimEnd('\\').TrimEnd(':');
                    Grid fill = FindChild<Grid>(HDD_Stack, childn);

                    HDDSize usedval = convertDriveSize(info.used);
                    HDDSize freeval = convertDriveSize(info.space);
                    #region Fill_Textual
                    if (fill != null)
                    {
                        fill.Children.OfType<StackPanel>().ToList().ForEach(b => fill.Children.Remove(b)); ;
                        StackPanel InfoStack = new StackPanel();
                        InfoStack.Margin = new Thickness(10, 0, 10, 0);
                        InfoStack.VerticalAlignment = VerticalAlignment.Center;
                        TextBlock name = new TextBlock();
                        name.Text = info.drive_name;
                        name.TextAlignment = TextAlignment.Center;
                        InfoStack.Children.Add(name);
                        TextBlock total = new TextBlock();
                        total.Text = "Free: " + freeval.size + " " + freeval.post;
                        total.TextAlignment = TextAlignment.Center;
                        InfoStack.Children.Add(total);
                        TextBlock used = new TextBlock();
                        used.Text = "Used: " + usedval.size + " " + usedval.post;
                        used.TextAlignment = TextAlignment.Center;
                        InfoStack.Children.Add(used);
                        InfoStack.SetValue(Grid.ColumnProperty, 1);
                        fill.Children.Add(InfoStack);

                    }
                    #endregion 
                    HDDInfo current_info = DisplayedHDDs.drives.FirstOrDefault(o => o.drive_name == d.Name);
                    #region FillPies
                    if (current_info == null)
                    {
                        DisplayedHDDs.drives.Add(info);
                        createUpdatePie(info, freeval, usedval);
                    }
                    else
                    {
                        long percentage = d.TotalSize / 50; //return 2% of the drive size
                        long currfree = current_info.space;
                        long currused = current_info.used;
                        #region LowDiskSpaceCheck
                        if (currfree < (percentage * 5))
                        {
                            if (Properties.Settings.Default.LDS_Warn)
                            {
                                bool LDUWarnMessage = Properties.Settings.Default.LDUWarnMessage;
                                if (!LDUWarnMessage)
                                {
                                    ProgramMessages pm = new ProgramMessages();
                                    pm.MessageType = "LDU";
                                    pm.SetMessage("Drive " + d.Name + " reports Low Disk Space (<10%)");
                                    pm.SetButtons("OK","Ignore");
                                    pm.Show();
                                }
                            }
                        }
                        #endregion

                        #region DiskUsageCheck

                        checkDiskUsage.Enabled = true;
                        

                        #endregion

                        #region CheckUpdatePie
                        if (currfree - info.space > percentage || info.space - currfree > percentage)
                        {
                            DisplayedHDDs.drives.FirstOrDefault(o => o.drive_name == d.Name).space = info.space;
                            DisplayedHDDs.drives.FirstOrDefault(o => o.drive_name == d.Name).update_pie = true;
                        }
                        if (currused - info.used > percentage || info.used - currused > percentage)
                        {
                            DisplayedHDDs.drives.FirstOrDefault(o => o.drive_name == d.Name).used = info.used;
                            DisplayedHDDs.drives.FirstOrDefault(o => o.drive_name == d.Name).update_pie = true;
                        }
                       //Update Pie Chart?
                        if (DisplayedHDDs.drives.FirstOrDefault(o => o.drive_name == d.Name).update_pie == true)
                        {
                            createUpdatePie(info, freeval, usedval);
                        }
                        else
                        {
                            Console.WriteLine("No Need For Update");
                        }
                        #endregion
                    }
                    #endregion
                }
            }
        }

        private void createUpdatePie(HDDInfo info, HDDSize freeval, HDDSize usedval)
        {
            //Figure out what grid we are working with
            String gridName = info.drive_name.TrimEnd('\\').TrimEnd(':');

            Grid thisGrid = FindChild<Grid>(HDD_Stack, gridName);

            double f = freeval.size;
            double u = usedval.size;
            //UpdatePieCharts(f, u);


            ChartValues<double> fv = new ChartValues<double> { f };
            ChartValues<double> uv = new ChartValues<double> { u };
            PieChart pie = new PieChart();
            pie.LegendLocation = LegendLocation.None;
            PieSeries usedslice = new PieSeries();
            PieSeries freeslice = new PieSeries();
            usedslice.LabelPosition = PieLabelPosition.InsideSlice;
            freeslice.LabelPosition = PieLabelPosition.InsideSlice;
            usedslice.DataLabels = false;
            freeslice.DataLabels = false;
            usedslice.Values = uv;
            freeslice.Values = fv;
            pie.Series.Add(usedslice);
            pie.Series.Add(freeslice);
            pie.Width = 90;
            pie.Height = 90;
            pie.SetValue(Grid.ColumnProperty, 0);
            thisGrid.Children.Add(pie);

        }
        public HDDSize convertDriveSize(double value)
        {
            
            double DriveSize;
            string postfix = "Bytes";
            double result = value;
            if (result >= 1099511627776) //larger than a TB
            {
                result = value / 1099511627776;
                postfix = "TB";
            }
            else if (result >= 1073741824) // larger than a GB
            {
                result = value / 1073741824;
                postfix = "GB";
            }
            else if (value >= 1048576)//more that 1 MB
            {
                result = value / 1048576;
                postfix = "MB";
            }
            else if (value >= 1024)//more that 1 KB
            {
                result = value / 1024;
                postfix = "KB";
            }
            result = Math.Round(result, 2);
            DriveSize = result;

            HDDSize values = new HDDSize();
            values.size = DriveSize;
            values.post = postfix;
            return values;
        }

        private void Hdds_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            checkHddValues.Enabled = false;
            checkDiskUsage.Enabled = false;
            checkHddValues.Dispose();
            checkDiskUsage.Dispose();
        }
    
    }
}
