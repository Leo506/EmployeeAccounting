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
using EmployeeAccounting.ViewModels;

namespace EmployeeAccounting
{
    /// <summary>
    /// Логика взаимодействия для DepartmentSelection.xaml
    /// </summary>
    public partial class DepartmentSelection : Window
    {
        DepartmentSelectionViewModel viewModel;
        public DepartmentSelection(EmployerViewModel employerViewModel)
        {
            InitializeComponent();
            viewModel = new DepartmentSelectionViewModel(employerViewModel);
            DataContext = viewModel;
        }

        private void OnChoose(object sender, RoutedEventArgs e)
        {
            viewModel.OnChoose();
            DialogResult = true;
        }
    }
}
