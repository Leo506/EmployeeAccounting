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
    /// Логика взаимодействия для RoleSelection.xaml
    /// </summary>
    public partial class RoleSelection : Window
    {
        RoleSelectionViewModel viewModel;
        public RoleSelection()
        {
            InitializeComponent();
            viewModel = new RoleSelectionViewModel();
            DataContext = viewModel;
        }


        private void OnChoose(object sender, RoutedEventArgs e)
        {
            viewModel.OnSelectorChoose();
            DialogResult = true;
        }
    }
}
