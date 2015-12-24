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

namespace AdoExam
{
    /// <summary>
    /// Interaction logic for SlWindow.xaml
    /// </summary>
    public partial class SlWindow : Window
    {
        public SlWindow()
        {
            InitializeComponent();
            tblHello.Text = "Здравствуйте, " + App.userName;
            tblDate.Text = "Сегодня: " + DateTime.Now.ToShortDateString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Seller.GoodList gl = new Seller.GoodList(false);
            gl.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Seller.CustomerList cl = new Seller.CustomerList();
            cl.Show();
        }
    }
}
