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

namespace EmployeeAccounting
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            ChoiceHead.IsEnabled = false;
            DepartmentNameInput.IsEnabled = false;
        }

        private void OnTypeChange(object sender, SelectionChangedEventArgs e)
        {
            string type = ((TextBlock)TypeInput.SelectedItem).Text;
            switch (type)
            {
                case "Работник":
                    ChoiceHead.IsEnabled = true;
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
    }
}
