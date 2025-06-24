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
    public partial class ManageCoursesWindow : Window
    {
        public ManageCoursesWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using var db = new StuDBContext();
            var data = db.Courses.Include(c => c.Instructor).ToList();
            dataGrid.ItemsSource = data;
        }

        // Add, Edit, Delete logic omitted for brevity — same as before
    }
}
