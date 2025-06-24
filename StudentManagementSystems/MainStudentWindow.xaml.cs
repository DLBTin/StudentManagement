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
    public partial class MainStudentWindow : Window
    {
        private int _studentId;

        public MainStudentWindow(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
        }

        private void BtnMyCourses_Click(object sender, RoutedEventArgs e) => new MyCoursesWindow(_studentId).Show();
        private void BtnRegister_Click(object sender, RoutedEventArgs e) => new RegisterCourseWindow(_studentId).Show();
    }
}
