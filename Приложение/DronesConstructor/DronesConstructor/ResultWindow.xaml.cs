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
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        List<DroneComponentsClass.ModuleType> moduleTypesList;
        public DroneComponentsClass droneComponentsClass;
        public DroneComponentsClass.Characteristics characteristics;
        public DataBaseClass dataBaseClass;
        public ResultWindow(DroneComponentsClass.Characteristics _characteristics, DroneComponentsClass _droneComponentsClass, DataBaseClass _dataBaseClass)
        {
            InitializeComponent();
            droneComponentsClass = _droneComponentsClass;
            characteristics = _characteristics;
            dataBaseClass = _dataBaseClass;
            moduleTypesList = new List<DroneComponentsClass.ModuleType>();
            foreach (int module in droneComponentsClass.characteristics.modules)
            {
                DroneComponentsClass.ModuleType moduleType;
                moduleType = new DroneComponentsClass.ModuleType
                {
                    ID = 0,
                    name = dataBaseClass.GetCell($"Select НаименованиеМодуля From Модуль where IDМодуля = {module}").ToString(),
                    active = false,
                    weight = Convert.ToDouble(dataBaseClass.GetCell($"Select МассаМодуля From Модуль where IDМодуля = {module}").ToString()),

                };
                moduleTypesList.Add(moduleType);
            }
            motorLabel.Content = dataBaseClass.GetCell($"Select НаименованиеМотора From Мотор where IDМотора = {droneComponentsClass.motorCharacteristics.motor.ID}");
            propLabel.Content = droneComponentsClass.characteristics.propName;
            batteryLabel.Content = dataBaseClass.GetCell($"Select НаименованиеБатареи From Батарея where IDБатареи = {droneComponentsClass.battery.ID}");
            boardLabel.Content = dataBaseClass.GetCell($"Select НаименованиеПлаты From Плата where IDПлаты = {droneComponentsClass.board.ID}");
            ESCLabel.Content = dataBaseClass.GetCell($"Select НаименованиеРегулятора From Регулятор where IDРегулятора = {droneComponentsClass.esc.ID}");

            moduleListView.ItemsSource = moduleTypesList;

            double weight = characteristics.frameWeight;
            weight += Convert.ToDouble(dataBaseClass.GetCell($"Select МассаБатареи From Батарея where IDБатареи = {droneComponentsClass.battery.ID}"));
            weight += Convert.ToDouble(dataBaseClass.GetCell($"Select МассаМотора From Мотор where IDМотора = {droneComponentsClass.motorCharacteristics.motor.ID}")) * characteristics.countOfProp;
            weight += Convert.ToDouble(dataBaseClass.GetCell($"Select МассаПропеллера From Пропеллер where НаименованиеПропеллера = '{droneComponentsClass.characteristics.propName}'")) * characteristics.countOfProp;
            weight += Convert.ToDouble(dataBaseClass.GetCell($"Select МассаПлаты From Плата where IDПлаты = {droneComponentsClass.board.ID}"));
            weight += Convert.ToDouble(dataBaseClass.GetCell($"Select МассаРегулятора From Регулятор where IDРегулятора = {droneComponentsClass.esc.ID}"));
            foreach (DroneComponentsClass.ModuleType moduleType in moduleTypesList)
            {
                weight+= moduleType.weight;
            }
            droneWeightLabel.Content = Math.Round((weight / 1000), 3);
            positiveLoadLabel.Content = Math.Round(((droneComponentsClass.characteristics.thrust * droneComponentsClass.characteristics.countOfProp - weight) / 1000), 2);
            RPMLabel.Content = droneComponentsClass.motorCharacteristics.motor.KV * droneComponentsClass.characteristics.fullValtage / 100 * 80;
            flightTimeLabel.Content = Math.Round((Convert.ToInt32(dataBaseClass.GetCell($"Select Емкость From Батарея where IDБатареи = {droneComponentsClass.battery.ID}")) / 1000 / (droneComponentsClass.motorCharacteristics.current * droneComponentsClass.characteristics.countOfProp) * 60), 2);
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            dataBaseClass.ExecuteComamnd($"Insert Into" +
                $" ТактикоТехническаяХарактеристика (" +
                $" [ПродолжительностьПолета]" +
                $",[ВзлетнаяМасса]" +
                $",[ОборотыВМинуту]" +
                $",[Грузоподьемность] )" +
                $" Values (" +
                $" {flightTimeLabel.Content}" +
                $", {droneWeightLabel.Content}" +
                $", {RPMLabel.Content}" +
                $", {positiveLoadLabel.Content} )");
            int IDCharactreistic = Convert.ToInt32(dataBaseClass.GetCell("Select max(IDХарактеристики) From ТактикоТехническаяХарактеристика"));
            dataBaseClass.ExecuteComamnd($"Insert Into" +
                $" КонструкцияДрона (" +
                $" [НаименованиеКонструкцииДрона]" +
                $",[ДатаКонструкции]" +
                $",[ТипДрона]" +
                $",[Характеристика]" +
                $",[Батарея]" +
                $",[Регулятор]" +
                $",[Мотор]" +
                $",[Плата] )" +
                $" Values (" +
                $" '{droneNameTextBox.Text}'," +
                $" GetDate()," +
                $" '{droneComponentsClass.characteristics.IDDroneType}'," +
                $" {IDCharactreistic}," +
                $" {droneComponentsClass.battery.ID}," +
                $" {droneComponentsClass.esc.ID}," +
                $" {droneComponentsClass.motorCharacteristics.ID}," +
                $" {droneComponentsClass.board.ID} )");
            int IDConstruction = Convert.ToInt32(dataBaseClass.GetCell("Select max(IDКонструкцииДрона) From КонструкцияДрона"));
            foreach (DroneComponentsClass.ModuleType module in moduleTypesList)
            {
                int moduleID = Convert.ToInt32(dataBaseClass.GetCell($"Select IDМодуля From Модуль Where НаименованиеМодуля = '{module.name}'"));
                dataBaseClass.ExecuteComamnd($"Insert Into" +
                    $" КонструкцияМодуль (" +
                    $" [IDКонструкции]" +
                    $",[IDМодуля] )" +
                    $" Values (" +
                    $" '{IDConstruction}'," +
                    $" {moduleID} )");
            }
            MessageBox.Show("Конструкция сохранена", "Успех");
        }
    }
}
