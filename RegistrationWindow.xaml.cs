using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data;

namespace AdoExam
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(App.conStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Department; SELECT Name FROM Position", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    cbDep.Items.Add(reader[0]);  
                }

                reader.NextResult();

                while (reader.Read())
                {
                    cbPos.Items.Add(reader[0]);
                }

                cbDep.SelectedIndex = 0;
                cbPos.SelectedIndex = 0;
            }
        }

        private void ButReg_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbAw.Text == "" || tbPass.Text == "" || tbSal.Text == "")
                MessageBox.Show("Error");
            else
            {
                SqlConnection con=new SqlConnection(App.conStr);

                SqlCommand insertComm = new SqlCommand
                    ("INSERT INTO Employee(Name,Password,DepartmentID,PositionID,Salary,Award,HireDate)"+ 
                    "VALUES (@Name,@Password,@DepartmentID,@PositionID,@Salary,@Award,@HireDate)", con);

                insertComm.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = tbName.Text;
                insertComm.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = tbPass.Text;
                insertComm.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = cbDep.SelectedIndex+1;
                insertComm.Parameters.Add("@PositionID", SqlDbType.Int).Value = cbPos.SelectedIndex+1;
                insertComm.Parameters.Add("@Salary", SqlDbType.Money).Value = Convert.ToDecimal(tbSal.Text);
                insertComm.Parameters.Add("@Award", SqlDbType.Money).Value = Convert.ToDecimal(tbAw.Text);
                insertComm.Parameters.Add("@HireDate", SqlDbType.SmallDateTime).Value = dpHire.DisplayDate; 

                con.Open();
                insertComm.ExecuteNonQuery();
                con.Close();

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            
                    }

        private void tbSal_LostFocus(dynamic sender, RoutedEventArgs e)
        {
            Regex reg = new Regex(@"[^0-9]");
            if (reg.IsMatch(sender.Text))
            {
            MessageBox.Show("Поле может содержать только цифры!");
            sender.Text = "";
            }
        }

        
    }
}
