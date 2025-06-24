using StudentManagementSystems.Models;
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

namespace StudentManagementSystems
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password.Trim();

            using (var db = new StuDBContext())
            {
                var acc = db.Accounts.FirstOrDefault(a => a.Username == username && a.PasswordHash == password);

                if (acc != null)
                {
                    if (acc.Role == "Admin")
                    {
                        new Admin.MainAdminWindow().Show();
                    }
                    else if (acc.Role == "Student")
                    {
                        new Student.MainStudentWindow(acc.StudentId.Value).Show();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }
    }
}
