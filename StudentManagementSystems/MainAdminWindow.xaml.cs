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
    public partial class MainAdminWindow : Window
    {
        public MainAdminWindow()
        {
            InitializeComponent();
        }

        private void BtnManageStudents_Click(object sender, RoutedEventArgs e) => new ManageStudentsWindow().Show();
        private void BtnManageInstructors_Click(object sender, RoutedEventArgs e) => new ManageInstructorsWindow().Show();
        private void BtnManageCourses_Click(object sender, RoutedEventArgs e) => new ManageCoursesWindow().Show();
        private void BtnReport_Click(object sender, RoutedEventArgs e) => new ReportWindow().Show();
    }
}
