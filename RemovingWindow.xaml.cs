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

            EmployerChoice.ItemsSource = viewModel.EmployerNames;
            HeadChoice.ItemsSource = viewModel.HeadsNames;
            HeadChoice.IsEnabled = false;
        }

        private void OnChoiceChange(object sender, SelectionChangedEventArgs e)
        {
            Trace.WriteLine(EmployerChoice.SelectedIndex);
            if (viewModel.IsHead(viewModel.Employers[EmployerChoice.SelectedIndex]))
                HeadChoice.IsEnabled = true;
            else
                HeadChoice.IsEnabled = false;
        }

        private void RemoveEmployer(object sender, RoutedEventArgs e)
        {
            string toRemove = viewModel.EmployerNames[EmployerChoice.SelectedIndex];

            int? replaceIndex = HeadChoice.SelectedIndex < 0 || HeadChoice.SelectedIndex >= viewModel.HeadsNames.Count ? null : HeadChoice.SelectedIndex;

            string? toReplace = replaceIndex == null ? null : viewModel.HeadsNames[replaceIndex.Value];

            viewModel.RemoveEmployer(toRemove, toReplace);

            DialogResult = true;
        }
    }
}
