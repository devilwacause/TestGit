using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WidgetDesktop
{
    class Utils
    {
        public static class MemberInfoGetting
        {
            public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                return expressionBody.Member.Name;
            }
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));

        }
        public static void ShowWindowOpen<T>(string name = "") where T : Window
        {
            Application.Current.Windows.OfType<T>().First().Activate();
        }

        public static void ListCounters(string categoryName)
        {
            PerformanceCounterCategory category = PerformanceCounterCategory.GetCategories().First(c => c.CategoryName == categoryName);
            Console.WriteLine("{0} [{1}]", category.CategoryName, category.CategoryType);

            string[] instanceNames = category.GetInstanceNames();

            if (instanceNames.Length > 0)
            {
                // MultiInstance categories
                foreach (string instanceName in instanceNames)
                {
                    ListInstances(category, instanceName);
                }
            }
            else
            {
                // SingleInstance categories
                ListInstances(category, string.Empty);
            }
        }

        private static void ListInstances(PerformanceCounterCategory category, string instanceName)
        {
            Console.WriteLine("    {0}", instanceName);
            PerformanceCounter[] counters = category.GetCounters(instanceName);

            foreach (PerformanceCounter counter in counters)
            {
                Console.WriteLine("        {0}", counter.CounterName);
            }
        }
    
    }
}
