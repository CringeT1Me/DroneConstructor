using DronesConstructor.Classes;
using ServiceApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace DronesConstructor
{
    /// <summary>
    /// Логика взаимодействия для SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        public int step = 0;
        public int maxStep = 4;
        public DroneComponentsClass droneComponentsClass;
        public DroneComponentsClass.Characteristics characteristics;
        public DataBaseClass dataBaseClass;
        DataTable dataTable;
        public bool condition = false;
        public string conditionString = string.Empty;
        public string selectString = string.Empty;
        public string queryString = string.Empty;
        public List<string> modules;
        List<DataTable> moduleDataTables;
        int IDDroneTypeForESC = 0;
        public SelectionWindow(DroneComponentsClass _droneComponentsClass, DataBaseClass _dataBaseClass, DroneComponentsClass.Characteristics _characteristics, List<string> _modules)
        {
            InitializeComponent();
            droneComponentsClass = _droneComponentsClass;
            characteristics = _characteristics;
            dataBaseClass = _dataBaseClass;
            modules = _modules;
            moduleDataTables = new List<DataTable>();
            selectString = "Select" +
                " [НаименованиеМотора] as [Наименование\nмотора]" +
                ",[НаименованиеПропеллера] as [Пропеллер]" +
                ",[СкоростьВращения] as [Скорость\nвращения]" +
                ",[Напряжение]" +
                ",[МассаМотора] as [Масса\nмотора]" +
                ",[Газ]" +
                ",[СилаТока] as [Сила\nтока]" +
                ",[Тяга]" +
                ",[Мощность]" +
                ",[Температура]" +
                " From Мотор" +
                " Inner Join ХарактеристикаМотора on ХарактеристикаМотора.Мотор = Мотор.IDМотора" +
                " Inner Join Пропеллер on Пропеллер.IDПропеллера = ХарактеристикаМотора.Пропеллер" +
               $" Where Мотор.СкоростьВращения * Напряжение > {characteristics.RPM}" +
               $" and Газ = {characteristics.gas}" +
               $" and Тяга > {droneComponentsClass.characteristics.requiedThrust}".Replace(",",".");
            if (characteristics.minValtage != 0)
            {
                selectString += $" and Напряжение > '{characteristics.minValtage.ToString().Replace(",", ".")}'";
            }
            if (characteristics.maxValtage != 0)
            {
                selectString += $" and Напряжение < '{characteristics.maxValtage.ToString().Replace(",",".")}'";
            }
            dataGrid.ItemsSource = dataBaseClass.GetTable(selectString).DefaultView;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            step++;
            DataRowView dataRowView = dataGrid.SelectedItem as DataRowView;
            DataRow dataRow = dataRowView.Row;
            if (step == 1)
            {
                switch (characteristics.countOfProp)
                {
                    case 3:
                        {
                            droneComponentsClass.characteristics.IDDroneType = 0;
                            IDDroneTypeForESC = 1;
                            break;
                        }
                    case 4:
                        {
                            droneComponentsClass.characteristics.IDDroneType = 1;
                            IDDroneTypeForESC = 1;

                            break;
                        }
                    case 6:
                        {
                            droneComponentsClass.characteristics.IDDroneType = 2;
                            IDDroneTypeForESC = 2;

                            break;
                        }
                    case 8:
                        {
                            droneComponentsClass.characteristics.IDDroneType = 3;
                            IDDroneTypeForESC = 3;

                            break;
                        }
                }
                droneComponentsClass.motorCharacteristics.current = Convert.ToDouble(dataRow[6].ToString());
                dataTable = dataBaseClass.GetTable($"Select *" +
                    $" From Батарея" +
                    $" Where Емкость >= ({characteristics.flightTime} / 60.0 * {droneComponentsClass.motorCharacteristics.current * characteristics.countOfProp})  * 1000 / 100 * 120" +
                    $" and ЧислоЯчеек >= {characteristics.minCells}" +
                    $" and ЧислоЯчеек <= {characteristics.maxCells}" +
                    $" order by МассаБатареи asc");
                if (dataTable.Rows.Count <= 0)
                {
                    MessageBox.Show("Слишком большая продолжительность полета для такой характеристики. Попробуйте выбрать мотор с меньшим потреблением тока или изменить характеристику.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    step = 0;
                }
                else
                {
                    droneComponentsClass.characteristics.propName = dataRow[1].ToString();
                    droneComponentsClass.characteristics.thrust = Convert.ToDouble(dataRow[7].ToString());
                    droneComponentsClass.motorCharacteristics.motor.KV = Convert.ToDouble(dataRow[2].ToString());
                    droneComponentsClass.characteristics.fullValtage = Convert.ToDouble(dataRow[3].ToString());
                    droneComponentsClass.motorCharacteristics.motor.ID = Convert.ToInt32(dataBaseClass.GetCell($"Select IDМотора" +
                        $" From Мотор" +
                        $" Inner Join ХарактеристикаМотора on ХарактеристикаМотора.Мотор = Мотор.IDМотора" +
                        $" Inner Join Пропеллер on Пропеллер.IDПропеллера = ХарактеристикаМотора.Пропеллер" +
                        $" where НаименованиеПропеллера = '{dataRow[1]}'" +
                        $" and Мотор.НаименованиеМотора = '{dataRow[0]}'"));
                    droneComponentsClass.motorCharacteristics.ID = Convert.ToInt32(dataBaseClass.GetCell($"Select IDХарактеристики" +
                        $" From Мотор" +
                        $" Inner Join ХарактеристикаМотора on ХарактеристикаМотора.Мотор = Мотор.IDМотора" +
                        $" Inner Join Пропеллер on Пропеллер.IDПропеллера = ХарактеристикаМотора.Пропеллер" +
                        $" where НаименованиеПропеллера = '{dataRow[1]}'" +
                        $" and Мотор.НаименованиеМотора = '{dataRow[0]}'"));
                    droneComponentsClass.motorCharacteristics.maxCurrent = Convert.ToInt32(dataBaseClass.GetCell($"Select СилаТока" +
                        $" From Мотор" +
                        $" Inner Join ХарактеристикаМотора on ХарактеристикаМотора.Мотор = Мотор.IDМотора" +
                        $" Inner Join Пропеллер on Пропеллер.IDПропеллера = ХарактеристикаМотора.Пропеллер" +
                        $" where НаименованиеПропеллера = '{dataRow[1]}'" +
                        $" and Мотор.НаименованиеМотора = '{dataRow[0]}'" +
                        $" and Газ = 100"));
                    dataGrid.ItemsSource = dataTable.DefaultView;
                    dataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    dataGrid.Columns[1].Header = "Наименование\nбатареии";
                    dataGrid.Columns[2].Header = "Емкость";
                    dataGrid.Columns[3].Header = "Номинальный ток";
                    dataGrid.Columns[4].Header = "Число ячеек";
                    dataGrid.Columns[5].Header = "Масса";
                    stepLabel.Content = "Выберите батарею";
                }
            }
            else if (step == 2)
            {
                dataRowView = dataGrid.SelectedItem as DataRowView;
                dataRow = dataRowView.Row;
                droneComponentsClass.battery.ID = Convert.ToInt32(dataRow[0].ToString());
                droneComponentsClass.battery.capacity = Convert.ToInt32(dataRow[2].ToString());
                dataGrid.ItemsSource = dataBaseClass.GetTable("SELECT *" +
                    " FROM Регулятор" +
                   $" where МаксимальныйТок >= {droneComponentsClass.motorCharacteristics.maxCurrent}" +
                   $" and КоличествоЯчеекМакс <= {characteristics.maxCells}" +
                   $" and ТипДрона = {IDDroneTypeForESC}").DefaultView;
                dataGrid.Columns[0].Visibility = Visibility.Collapsed;
                dataGrid.Columns[1].Visibility = Visibility.Collapsed;
                dataGrid.Columns[2].Header = "Наименование\nрегулятора";
                dataGrid.Columns[3].Header = "Максимальный\nток";
                dataGrid.Columns[4].Header = "Минимальное\nчисло ячеек";
                dataGrid.Columns[5].Header = "Максимальное\nчисло ячеек";
                dataGrid.Columns[6].Header = "Масса";
                stepLabel.Content = "Выберите регулятор";
            }
            else if (step == 3)
            {
                dataRowView = dataGrid.SelectedItem as DataRowView;
                dataRow = dataRowView.Row;
                droneComponentsClass.esc.ID = Convert.ToInt32(dataRow[0].ToString());
                dataGrid.ItemsSource = dataBaseClass.GetTable("SELECT *" +
                   " FROM Плата" +
                  $" where КоличествоЯчеекМакс >= {characteristics.maxCells}").DefaultView;
                dataGrid.Columns[0].Visibility = Visibility.Collapsed;
                dataGrid.Columns[1].Header = "Наименование\nплаты";
                dataGrid.Columns[2].Header = "Минимальное\nчисло ячеек";
                dataGrid.Columns[3].Header = "Максимальное\nчисло ячеек";
                dataGrid.Columns[5].Header = "Масса";
                stepLabel.Content = "Выберите плату";
            }
            else if (step == 4)
            {
                dataRowView = dataGrid.SelectedItem as DataRowView;
                dataRow = dataRowView.Row;
                droneComponentsClass.board.ID = Convert.ToInt32(dataRow[0].ToString());
                droneComponentsClass.characteristics.modules = new List<int> { };
                foreach (string module in modules)
                {
                    moduleDataTables.Add(dataBaseClass.GetTable("Select" +
                        " IDМодуля," +
                        " Модуль.НаименованиеМодуля as Наименование," +
                        " ТипМодуля.НаименованиеМодуля as 'Тип модуля'," +
                        " МассаМодуля" +
                        " From Модуль" +
                        " Inner Join ТипМодуля on Модуль.ТипМодуля = ТипМодуля.IDТипаМодуля" +
                    $" where ТипМодуля.НаименованиеМодуля = '{module}'"));
                    dataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    maxStep += moduleDataTables.Count - 1;
                }
                if (step != maxStep)
                {
                    stepLabel.Content = "Выберите модуль";
                    dataGrid.ItemsSource = moduleDataTables[0].DefaultView;
                }

            }
            else if (step != maxStep && maxStep > step)
            {
                try
                {
                    dataRowView = dataGrid.SelectedItem as DataRowView;
                    dataRow = dataRowView.Row;
                    droneComponentsClass.characteristics.modules.Add(Convert.ToInt32(dataRow[0]));
                    dataGrid.ItemsSource = moduleDataTables[moduleDataTables.Count - (maxStep - (step))].DefaultView;
                }
                catch { }
                
            }
            else if (step >= maxStep)
            {
                if (moduleDataTables.Count != 0)
                {
                    dataRowView = dataGrid.SelectedItem as DataRowView;
                    dataRow = dataRowView.Row;
                    droneComponentsClass.characteristics.modules.Add(Convert.ToInt32(dataRow[0]));
                }
                ResultWindow resultWindow = new ResultWindow(characteristics, droneComponentsClass, dataBaseClass);
                resultWindow.ShowDialog();
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            applyButton_Click(sender, e);
        }
    }
}
