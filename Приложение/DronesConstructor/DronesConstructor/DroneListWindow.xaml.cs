using DronesConstructor.Classes;
using ServiceApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для DroneListWindow.xaml
    /// </summary>
    public partial class DroneListWindow : Window
    {
        DataBaseClass dataBaseClass;
        List<DroneComponentsClass> components;
        DroneComponentsClass droneComponentsClass;
        public DroneListWindow(DataBaseClass _dataBaseClass)
        {
            InitializeComponent();
            dataBaseClass = _dataBaseClass;
            droneComponentsClass = new DroneComponentsClass();
            components = new List<DroneComponentsClass>();
            BuildList();
        }

        public void BuildList()
        {
            List<DroneComponentsClass> droneList = (from dataRow in dataBaseClass.GetTable("Select * From КонструкцияДрона").AsEnumerable()
                                        select new DroneComponentsClass
                                        {
                                            ID = dataRow.Field<int>("IDКонструкцииДрона"),
                                            name = dataRow.Field<string>("НаименованиеКонструкцииДрона"),
                                            date = dataRow.Field<DateTime>("ДатаКонструкции").ToString(),
                                            droneTypeID = dataRow.Field<int>("ТипДрона"),
                                        }).ToList();
            List<DroneComponentsClass.Battery> batteryList = (from dataRow in dataBaseClass.GetTable("Select * From Батарея").AsEnumerable()
                                                    select new DroneComponentsClass.Battery
                                                    {
                                                        ID = dataRow.Field<int>("IDБатареи"),
                                                        name = dataRow.Field<string>("НаименованиеБатареи"),
                                                        capacity = Convert.ToDouble(dataRow.Field<object>("Емкость")),
                                                        dischargeRating = Convert.ToDouble(dataRow.Field<object>("НоминальныйТокРазряда")),
                                                        cellCount = Convert.ToInt32(dataRow.Field<object>("ЧислоЯчеек")),
                                                        weight = Convert.ToDouble(dataRow.Field<object>("МассаБатареи")),
                                                    }).ToList();
            List<DroneComponentsClass.Motor> motorList = (from dataRow in dataBaseClass.GetTable("Select * From Мотор").AsEnumerable()
                                                          select new DroneComponentsClass.Motor
                                                          {
                                                              ID = dataRow.Field<int>("IDМотора"),
                                                              name = dataRow.Field<string>("НаименованиеМотора"),
                                                              KV = Convert.ToDouble(dataRow.Field<object>("СкоростьВращения")),
                                                              voltage = Convert.ToDouble(dataRow.Field<object>("Напряжение")),
                                                              weight = Convert.ToDouble(dataRow.Field<object>("МассаМотора")),
                                                          }).ToList();

            List<DroneComponentsClass.ESC> escList = (from dataRow in dataBaseClass.GetTable("Select * From Регулятор").AsEnumerable()
                                                      select new DroneComponentsClass.ESC
                                                      {
                                                          ID = dataRow.Field<int>("IDРегулятора"),
                                                          name = dataRow.Field<string>("НаименованиеРегулятора"),
                                                          maxCurrent = Convert.ToDouble(dataRow.Field<object>("МаксимальныйТок")),
                                                          minCellsCount = dataRow.Field<int>("КоличествоЯчеекМин"),
                                                          maxCellsCount = dataRow.Field<int>("КоличествоЯчеекМакс"),
                                                          weight = Convert.ToDouble(dataRow.Field<object>("МассаРегулятора")),
                                                      }).ToList();

            List<DroneComponentsClass.Board> boardList = (from dataRow in dataBaseClass.GetTable("Select * From Плата").AsEnumerable()
                                                          select new DroneComponentsClass.Board
                                                          {
                                                              ID = dataRow.Field<int>("IDПлаты"),
                                                              name = dataRow.Field<string>("НаименованиеПлаты"),
                                                              minCellsCount = dataRow.Field<int>("КоличествоЯчеекМин"),
                                                              maxCellsCount = dataRow.Field<int>("КоличествоЯчеекМакс"),
                                                              specification = dataRow.Field<string>("Cпецификация"),
                                                              weight = Convert.ToDouble(dataRow.Field<object>("МассаПлаты")),
                                                          }).ToList();
            List<DroneComponentsClass.MotorCharacteristics> motorCharacteristicsList = (from dataRow in dataBaseClass.GetTable("Select * From ХарактеристикаМотора").AsEnumerable()
                                                          select new DroneComponentsClass.MotorCharacteristics
                                                          {
                                                              ID = dataRow.Field<int>("IDХарактеристики"),
                                                              current = Convert.ToDouble(dataRow.Field<object>("СилаТока")),
                                                              thrust = Convert.ToDouble(dataRow.Field<object>("Тяга")),
                                                              gas = dataRow.Field<int>("Газ"),
                                                          }).ToList();

            List<DroneComponentsClass.Module> moduleList = (from dataRow in dataBaseClass.GetTable("Select * From Модуль").AsEnumerable()
                                                                  select new DroneComponentsClass.Module
                                                                  {
                                                                      ID = dataRow.Field<int>("IDМодуля"),
                                                                      name = dataRow.Field<string>("НаименованиеМодуля"),
                                                                      weight = Convert.ToDouble(dataRow.Field<object>("МассаМодуля")),
                                                                  }).ToList();
            List<DroneComponentsClass.ConstructionModule> constructionModuleList = (from dataRow in dataBaseClass.GetTable("Select * From КонструкцияМодуль").AsEnumerable()
                                                                        select new DroneComponentsClass.ConstructionModule
                                                                        {
                                                                            ID = dataRow.Field<int>("IDСвязи"),
                                                                            IDConstruction = dataRow.Field<int>("IDКонструкции"),
                                                                            IDModule = dataRow.Field<int>("IDМодуля"),
                                                                        }).ToList();

            List<DroneComponentsClass.Propeller> propellerList = (from dataRow in dataBaseClass.GetTable("Select * From Пропеллер").AsEnumerable()
                                                                                        select new DroneComponentsClass.Propeller
                                                                                        {
                                                                                            ID = dataRow.Field<int>("IDПропеллера"),
                                                                                            name = dataRow.Field<string>("НаименованиеПропеллера"),
                                                                                            weight = Convert.ToDouble(dataRow.Field<object>("МассаПропеллера")),
                                                                                        }).ToList();

            List<DroneComponentsClass.Characteristics> characteristicsList = (from dataRow in dataBaseClass.GetTable("Select * From ТактикоТехническаяХарактеристика").AsEnumerable()
                                                                              select new DroneComponentsClass.Characteristics
                                                                              {
                                                                                  ID = dataRow.Field<int>("IDХарактеристики"),
                                                                                  flightTime = Convert.ToDouble(dataRow.Field<object>("ПродолжительностьПолета")),
                                                                                  fullWeight = Convert.ToDouble(dataRow.Field<object>("ВзлетнаяМасса")),
                                                                                  RPM = Convert.ToDouble(dataRow.Field<object>("ОборотыВМинуту")),
                                                                                  positiveLoad = Convert.ToDouble(dataRow.Field<object>("Грузоподьемность")),
                                                                              }).ToList();
            List<DroneComponentsClass.DroneType> droneTypes = (from dataRow in dataBaseClass.GetTable("Select * From ТипДрона").AsEnumerable()
                                                               select new DroneComponentsClass.DroneType
                                                               {
                                                                   ID = dataRow.Field<int>("IDТипаДрона"),
                                                                   name = dataRow.Field<string>("НаименованиеТипаДрона"),
                                                                   imageByteArray = (dataRow.Field<byte[]>("Изображение")),
                                                                              }).ToList();
            foreach (DroneComponentsClass.MotorCharacteristics motorCharacteristics in motorCharacteristicsList)
            {
                DataRow dataRow = dataBaseClass.GetTable($"Select * From ХарактеристикаМотора where IDХарактеристики = {motorCharacteristics.ID}").Rows[0];
                motorCharacteristics.motor = motorList.First(x => x.ID == Convert.ToInt32(dataRow["Мотор"].ToString()));
                motorCharacteristics.propeller = propellerList.First(x => x.ID == Convert.ToInt32(dataRow["Мотор"].ToString()));

            }
            foreach (DroneComponentsClass drone in droneList)
            {
                DataRow droneDataRow = dataBaseClass.GetTable($"Select * From КонструкцияДрона where IDКонструкцииДрона = {drone.ID}").Rows[0];
                drone.battery = batteryList.First(x => x.ID == Convert.ToInt32(droneDataRow["Батарея"].ToString()));
                drone.motorCharacteristics = motorCharacteristicsList.First(x => x.ID == Convert.ToInt32(droneDataRow["Мотор"].ToString()));
                drone.esc = escList.First(x => x.ID == Convert.ToInt32(droneDataRow["Регулятор"].ToString()));
                drone.board = boardList.First(x => x.ID == Convert.ToInt32(droneDataRow["Плата"].ToString()));
                drone.characteristics = characteristicsList.First(x => x.ID == Convert.ToInt32(droneDataRow["Характеристика"].ToString()));
                drone.droneType = droneTypes.First(x => x.ID == Convert.ToInt32(droneDataRow["ТипДрона"].ToString()));
                BitmapImage image = new BitmapImage();
                using (var stream = new MemoryStream(drone.droneType.imageByteArray))
                {
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = stream;
                    image.EndInit();
                    image.Freeze();
                }
                drone.image = image;
                DataTable modulesDataTable = dataBaseClass.GetTable($"Select * From КонструкцияМодуль where IDКонструкции = {drone.ID}");
                foreach (DroneComponentsClass.ConstructionModule constructionModule in constructionModuleList.Where(constructionModule => constructionModule.IDConstruction == drone.ID))
                {
                    drone.modules.Add(moduleList.First(module => module.ID == constructionModule.IDModule));
                }
            }

            droneListView.ItemsSource = droneList;
        }

        private void droneListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListView listView = sender as ListView;
            DroneComponentsClass droneComponents = (DroneComponentsClass)listView.SelectedItem;
            DroneWindow droneWindow = new DroneWindow(droneComponents, dataBaseClass);
            droneWindow.ShowDialog();
            BuildList();
        }
    }
}
