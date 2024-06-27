using DronesConstructor.Classes;
using ServiceApp;
using System;
using System.Collections.Generic;
using System.Data;
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
using static DronesConstructor.Classes.DroneComponentsClass;

namespace DronesConstructor
{
    /// <summary>
    /// Логика взаимодействия для DroneDetailedComponentsWindow.xaml
    /// </summary>
    public partial class DroneDetailedComponentsWindow : Window
    {
        DataBaseClass dataBaseClass;
        public DroneDetailedComponentsWindow(DataBaseClass _dataBaseClass)
        {
            InitializeComponent();
            dataBaseClass = _dataBaseClass;
            motorDataGrid.ItemsSource = dataBaseClass.GetTable("Select * From Мотор" +
                " Inner Join ХарактеристикаМотора on ХарактеристикаМотора.Мотор = Мотор.IDМотора" +
                " Inner Join Пропеллер on Пропеллер.IDПропеллера = ХарактеристикаМотора.Пропеллер").DefaultView;
            batteryDataGrid.ItemsSource = dataBaseClass.GetTable($"Select * From Батарея").DefaultView;
            escDataGrid.ItemsSource = dataBaseClass.GetTable("SELECT * FROM Регулятор").DefaultView;
            boardDataGrid.ItemsSource = dataBaseClass.GetTable("SELECT * FROM Плата").DefaultView;
            propDataGrid.ItemsSource = dataBaseClass.GetTable("SELECT * FROM Пропеллер").DefaultView;
            moduleDataGrid.ItemsSource = dataBaseClass.GetTable("SELECT * FROM Модуль").DefaultView;
        }

        private void AddBattery_Click(object sender, RoutedEventArgs e)
        {
            AddBatteryWindow addBatteryWindow = new AddBatteryWindow(dataBaseClass);
            addBatteryWindow.ShowDialog();
        }

        private void EditBattery_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = batteryDataGrid.SelectedItem as DataRowView;
            DataRow dataRow = dataRowView.Row;
            AddBatteryWindow addBatteryWindow = new AddBatteryWindow(dataBaseClass, Convert.ToInt32(dataRow[0]));
            addBatteryWindow.ShowDialog();
        }

        private void DeleteBattery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddMotor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditMotor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DeleteMotor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
