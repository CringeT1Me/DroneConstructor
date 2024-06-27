using DronesConstructor.Classes;
using ServiceApp;
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

namespace DronesConstructor
{
    /// <summary>
    /// Логика взаимодействия для DroneComponentsWindow.xaml
    /// </summary>
    public partial class DroneComponentsWindow : Window
    {
        DataBaseClass dataBaseClass;
        public DroneComponentsClass.Characteristics characteristics;
        public DroneComponentsWindow(DroneComponentsClass.Characteristics _characteristics, DataBaseClass _dataBaseClass)
        {
            InitializeComponent();
            dataBaseClass = _dataBaseClass;
            characteristics = _characteristics;
            gasComboBox.Text = characteristics.gas.ToString() + "%";
            countOfPropComboBox.Text = characteristics.countOfProp.ToString();
            ratioComboBox.Text = characteristics.thrustRatio.ToString() + ":1";
            minValtageTextBox.Text = characteristics.minValtage.ToString();
            maxValtageTextBox.Text = characteristics.maxValtage.ToString();

        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            characteristics.gas = Convert.ToInt32(gasComboBox.Text.Replace("%", "").ToString());
            characteristics.countOfProp = Convert.ToInt32(countOfPropComboBox.Text.ToString());
            characteristics.thrustRatio = Convert.ToInt32(ratioComboBox.Text.Remove(1).ToString());
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minValtageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double value;
            var component = (TextBox)sender;
            if (component.Text != string.Empty)
            {
                if (double.TryParse(component.Text, out value))
                {
                    int minCells = (int)Math.Ceiling(value/3.7);
                    characteristics.minCells = minCells;
                    characteristics.minValtage = value;
                }
                else
                {
                    MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    component.Text = string.Empty;
                }
            }
        }

        private void maxValtageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double value;
            var component = (TextBox)sender;
            if (component.Text != string.Empty)
            {
                if (double.TryParse(component.Text, out value))
                {
                    int maxCells = (int)Math.Ceiling(value/3.7);
                    characteristics.maxCells = maxCells;
                    characteristics.maxValtage = value;
                }
                else
                {
                    MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    component.Text = string.Empty;
                }
            }
        }

        private void componentsButton_Click(object sender, RoutedEventArgs e)
        {
            DroneDetailedComponentsWindow droneDetailedComponentsWindow = new DroneDetailedComponentsWindow(dataBaseClass);
            droneDetailedComponentsWindow.ShowDialog();
        }
    }
}
