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
using EmployeeAccounting.ViewModels;

namespace EmployeeAccounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployerViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new EmployerViewModel();
            DataContext = viewModel;
        }

        private void ShowEmployerInfo(object sender, RoutedEventArgs e)
        {
            string? info = viewModel.GetInfo(((TextBlock)sender).Text);
            Info.Text = info;
        }

        private void ShowAddingForm(object sender, RoutedEventArgs e)
        {
            var adding = new AddWindow();
            adding.ShowDialog();
            viewModel.UpdateData();
        }

        private void ShowRemovingForm(object sender, RoutedEventArgs e)
        {
            var removing = new RemovingWindow();
            removing.ShowDialog();
            viewModel.UpdateData();
        }

        private void ShowEditForm(object sender, RoutedEventArgs e)
        {
            var editing = new EditWindow();
            editing.ShowDialog();
            viewModel.UpdateData();
        }

        private void ShowRoleSelection(object sender, RoutedEventArgs e)
        {
            var role = new RoleSelection();
            role.ShowDialog();
        }

        private void ShowDepartmentSelection(object sender, RoutedEventArgs e)
        {
            var dep = new DepartmentSelection(viewModel);
            dep.ShowDialog();
        }
    }
}
