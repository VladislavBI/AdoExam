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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace AdoExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ButEnt_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(App.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Password FROM Employee WHERE Name = @EmpName", conn);
                
                if(tbName.Text!=null)
                cmd.Parameters.AddWithValue("EmpName", tbName.Text);     
                else
                cmd.Parameters.AddWithValue("EmpName", "false");

                object pass = cmd.ExecuteScalar();
                if (pass == null)
                    MessageBox.Show("The user is not regitered!");
                else
                {

                    if (pbPassw.Password == pass.ToString())
                    {
                        cmd = new SqlCommand("SELECT PositionID FROM Employee WHERE Name = @EmpName;", conn);
                        cmd.Parameters.AddWithValue("EmpName", tbName.Text);
                        int pss = (int)cmd.ExecuteScalar();

                        if (pss == 1)
                        {
                            App.admin = true;
                        }
                        MnWindow mw = new MnWindow();
                        mw.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password!");
                    }
                }
            }
           

        }

        private void ButReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
            this.Close();
        }

    }
}
