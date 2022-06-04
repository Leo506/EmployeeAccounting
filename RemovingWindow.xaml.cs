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
    /// Логика взаимодействия для RemovingWindow.xaml
    /// </summary>
    public partial class RemovingWindow : Window
    {
        RemovingViewModel viewModel;
        public RemovingWindow()
        {
            InitializeComponent();

            viewModel = new RemovingViewModel();

            DataContext = viewModel;

            HeadChoice.IsEnabled = viewModel.NeedReplacement();
        }

        private void OnChoiceChange(object sender, SelectionChangedEventArgs e)
        {
            HeadChoice.IsEnabled = viewModel.NeedReplacement();
        }

        private void RemoveEmployer(object sender, RoutedEventArgs e)
        {
            if (!viewModel.Remove())
                MessageBox.Show("Error!!!");
            else
                DialogResult = true;
        }
    }
}
