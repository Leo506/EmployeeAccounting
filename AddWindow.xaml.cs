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

            ChoiceHead.ItemsSource = viewModel.DepartmentHeads;
        }

        private void OnTypeChange(object sender, SelectionChangedEventArgs e)
        {
            string type = ((TextBlock)TypeInput.SelectedItem).Text;
            switch (type)
            {
                case "Работник":
                    ChoiceHead.IsEnabled = true;
                    DepartmentNameInput.IsEnabled = false;
                    break;

                case "Руководитель":
                    DepartmentNameInput.IsEnabled = true;
                    ChoiceHead.IsEnabled = false;
                    break;

                default:
                    ChoiceHead.IsEnabled = false;
                    DepartmentNameInput.IsEnabled = false;
                    break;
            }
        }

        private void AddNewEmp(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;
            DateTime date = DateInput.SelectedDate.Value;
            Models.Gender sex = ((TextBlock)GenderInput.SelectedItem).Text == "Муж" ? Models.Gender.M : Models.Gender.F;
            string? depName = DepartmentNameInput.Text;
            string? headName = ChoiceHead.SelectedItem as string;

            Trace.WriteLine($"Name: {name}, headName: {ChoiceHead.SelectedItem}");

            if (!viewModel.AddNewEmployer(((TextBlock)TypeInput.SelectedItem).Text, name, date, sex, depName, headName))
            {
                MessageBox.Show("Error");
            }
        }
    }
}
