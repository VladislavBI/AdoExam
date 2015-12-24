using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;

namespace AdoExam.Seller
{
    /// <summary>
    /// Interaction logic for GoodList.xaml
    /// </summary>
    public partial class GoodList : Window
    {
        bool sell;
        public GoodList(bool sell)
        {
            InitializeComponent();
            this.sell = sell;
            FullCreate(); 
        }

        public void FullCreate() 
        {
           
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Good", App.conStr);
            adapter.Fill(ds);
            dgGoods.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Good WHERE Quantity<10", App.conStr);
            adapter.Fill(ds);
            dgGoods.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FullCreate();
        }

        private void dgGoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sell)
            {
                
            }
        }

        
    }
}
