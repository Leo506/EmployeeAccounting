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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        EditViewModel viewModel;
        public EditWindow()
        {
            InitializeComponent();
            viewModel = new EditViewModel();
            DataContext = viewModel;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (!viewModel.EditEmployer())
                MessageBox.Show("Error!!!");

            DialogResult = true;
        }
    }
}
