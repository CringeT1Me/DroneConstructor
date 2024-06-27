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
    /// Логика взаимодействия для DroneWindow.xaml
    /// </summary>
    public partial class DroneWindow : Window
    {
        DroneComponentsClass droneComponentsClass;
        DataBaseClass dataBaseClass;
        public DroneWindow(DroneComponentsClass _droneComponentsClass, DataBaseClass _dataBaseClass)
        {
            InitializeComponent();
            droneComponentsClass = _droneComponentsClass;
            dataBaseClass = _dataBaseClass;
            switch (droneComponentsClass.droneTypeID)
            {
                case 0:
                    typeLabel.Content += "трикоптера";
                    break;
                case 1:
                    typeLabel.Content += "квадрокоптера";
                    break;
                case 2:
                    typeLabel.Content += "гексакоптера";
                    break;
                case 3:
                    typeLabel.Content += "октокоптера";
                    break;
                default:
                    typeLabel.Content += "дрона";
                    break;
            }
            motorLabel.Content = droneComponentsClass.motorCharacteristics.motor.name;
            propLabel.Content = droneComponentsClass.motorCharacteristics.propeller.name;
            nameLabel.Content = droneComponentsClass.name;
            boardLabel.Content = droneComponentsClass.board.name;
            ESCLabel.Content = droneComponentsClass.esc.name;
            batteryLabel.Content = droneComponentsClass.battery.name;
            droneWeightLabel.Content = droneComponentsClass.characteristics.fullWeight;
            positiveLoadLabel.Content = droneComponentsClass.characteristics.positiveLoad;
            RPMLabel.Content = droneComponentsClass.characteristics.RPM;
            flightTimeLabel.Content = droneComponentsClass.characteristics.flightTime;
            moduleListView.ItemsSource = droneComponentsClass.modules;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            dataBaseClass.ExecuteComamnd($"Delete From ТактикоТехническаяХарактеристика where IDХарактеристики = {droneComponentsClass.characteristics.ID}");
            MessageBox.Show("Конструкция удалена", "Успех", MessageBoxButton.OK);
            this.Close();
        }
    }
}
