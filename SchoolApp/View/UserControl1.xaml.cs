using SchoolApp.Model;
using SchoolApp.ViewModel;
using SchoolApp.View;
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

namespace SchoolApp.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        // Declare the view-model field so code-behind compiles
        private StudentsViewModel vm;

        public UserControl1()
        {
            InitializeComponent();
             DataContext = new StudentDetailsViewModel();
            vm = new StudentsViewModel();
            this.DataContext = vm;
            this.Loaded += UserControl1_Loaded;
        }
        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            // Demo: insert one student and refresh list
            var newStudent = new Students { FirstName = "A", LastName = "B", Age = 10 };
            var id = vm.InsertStudent(newStudent); // safe: goes through ViewModel -> Repository
            vm.LoadAll();
        }

    }
}
