using System;
using System.Management;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Security.Principal;
using System.Globalization;

namespace WidgetDesktop
{
   

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        private const string RegistryValueName = "AppsUseLightTheme";

        bool isHighContrast = SystemParameters.HighContrast;


        private enum WindowsTheme
        {
            Light,
            Dark
        }
        public enum AppTheme
        {
            Light,
            Dark,
            HighContrast
        }
        public AppTheme appTheme = new AppTheme();
        public void WatchTheme()
        {
            var currentUser = WindowsIdentity.GetCurrent();
            string query = string.Format(
                CultureInfo.InvariantCulture,
                @"SELECT * FROM RegistryValueChangeEvent WHERE Hive = 'HKEY_USERS' AND KeyPath = '{0}\\{1}' AND ValueName = '{2}'",
                currentUser.User.Value,
                RegistryKeyPath.Replace(@"\", @"\\"),
                RegistryValueName);

            try
            {
                var watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += (sender, args) =>
                {
                    WindowsTheme newWindowsTheme = GetWindowsTheme();
                    // React to new theme
                    if (!isHighContrast)
                    {
                        if (newWindowsTheme == WindowsTheme.Dark)
                        {
                            appTheme = AppTheme.Dark;
                        }
                        else
                        {
                            appTheme = AppTheme.Light;
                        }
                    }
                    else
                    {
                        appTheme = AppTheme.HighContrast;
                    }

                    UpdateAppTheme();
                };

                // Start listening for events
                watcher.Start();
            }
            catch (Exception)
            {
                // This can fail on Windows 7
            }

            SystemParameters.StaticPropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == Utils.MemberInfoGetting.GetMemberName(() => SystemParameters.HighContrast))
                {
                    isHighContrast = SystemParameters.HighContrast;
                    if (!isHighContrast)
                    {
                        WindowsTheme newWindowsTheme = GetWindowsTheme();
                        if (newWindowsTheme == WindowsTheme.Dark)
                        {
                            appTheme = AppTheme.Dark;
                        }
                        else
                        {
                            appTheme = AppTheme.Light;
                        }
                    }
                    else
                    {
                        appTheme = AppTheme.HighContrast;
                    }
                    UpdateAppTheme();
                }
            };


            WindowsTheme initialTheme = GetWindowsTheme();
            if (!isHighContrast)
            {
                if (initialTheme == WindowsTheme.Dark)
                {
                    appTheme = AppTheme.Dark;
                }
                else
                {
                    appTheme = AppTheme.Light;
                }
            }
            else
            {
                appTheme = AppTheme.HighContrast;
            }
        }

        private static WindowsTheme GetWindowsTheme()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                object registryValueObject = key.GetValue(RegistryValueName);
                if (registryValueObject == null)
                {
                    return WindowsTheme.Light;
                }

                int registryValue = (int)registryValueObject;

                return registryValue > 0 ? WindowsTheme.Light : WindowsTheme.Dark;
            }
        }

        private void UpdateAppTheme()
        {
            Console.WriteLine("App Theme = " + appTheme);
            try
            {
                this.Resources.MergedDictionaries[0].Source = new Uri((@"/Assets/Themes/" + appTheme + ".xaml"), UriKind.Relative);
                Console.WriteLine(this.Resources.MergedDictionaries[0].Source);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            WatchTheme();
            UpdateAppTheme();            
        }
    }

       

}
