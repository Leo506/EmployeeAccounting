using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        AddingViewModel viewModel;

        public AddWindow()
        {
            InitializeComponent();
            ChoiceHead.IsEnabled = false;
            DepartmentNameInput.IsEnabled = false;

            viewModel = new AddingViewModel();

            DataContext = viewModel;
        }

        private void OnTypeChange(object sender, SelectionChangedEventArgs e)
        {
            ChoiceHead.IsEnabled = viewModel.NeedHead();
            DepartmentNameInput.IsEnabled = viewModel.NeedDepartment();
        }

        private void AddNewEmp(object sender, RoutedEventArgs e)
        {
            viewModel.AddNewEmployer();
        }
    }
}
