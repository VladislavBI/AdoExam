using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdoExam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool admin=false;
        public static string conStr = @"Data Source=localhost; Initial Catalog=AdoExam; Integrated Security=true; Pooling=true";
        public static string userName;
    }
}
