using DronesConstructor.Classes;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using ServiceApp;
using Mysqlx.Resultset;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Xml;
using System.Reflection;

namespace DronesConstructor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseClass dataBaseClass = new DataBaseClass("Data Source=DESKTOP-PA3DJO7;" +
            "Initial Catalog=DronesConstructions;Integrated Security=True");

        DroneComponentsClass droneComponentsClass;
        List<DroneComponentsClass.ModuleType> moduleTypesList;
        List<DroneComponentsClass.Objective> objectivesList;

        DroneComponentsClass.Characteristics characteristics;
        const string JSONFILENAME = "characteristics.json";
        string jsonString;

        public MainWindow()
        {
            InitializeComponent();
            droneComponentsClass = new DroneComponentsClass();
            characteristics = new DroneComponentsClass.Characteristics();


            jsonString = File.ReadAllText(JSONFILENAME);
            characteristics = JsonSerializer.Deserialize<DroneComponentsClass.Characteristics>(jsonString);
           
            GetTypeModules();
            GetObjectives();

            SetCharacteristicsToElements();
        }

        public void GetTypeModules()
        {
            moduleTypesList = new List<DroneComponentsClass.ModuleType>();
            foreach (DataRow dataRow in dataBaseClass.GetTable("Select * From ТипМодуля").Rows)
            {
                DroneComponentsClass.ModuleType moduleType;
                moduleType = new DroneComponentsClass.ModuleType
                {
                    ID = Convert.ToInt32(dataRow[0].ToString()),
                    name = dataRow[1].ToString(),
                    active = false
                };
                moduleTypesList.Add(moduleType);
            }
            moduleListView.ItemsSource = null;
            moduleListView.ItemsSource = moduleTypesList;
        }
        
        public void GetObjectives()
        {
            objectivesList = new List<DroneComponentsClass.Objective>();
            foreach (DataRow objectivesRow in dataBaseClass.GetTable("Select * From Задача").Rows)
            {
                DroneComponentsClass.Objective objective;
                List<int> requiedModuleTypesID = new List<int>();
                foreach (DataRow requiedModulesRow in dataBaseClass.GetTable($"Select IDТипаМодуля From ТребуемыйМодуль where IDЗадачи = {objectivesRow[0].ToString()}").Rows)
                {
                    requiedModuleTypesID.Add(Convert.ToInt32(requiedModulesRow[0].ToString()));
                }

                objective = new DroneComponentsClass.Objective
                {
                    ID = Convert.ToInt32(objectivesRow[0].ToString()),
                    name = objectivesRow[1].ToString(),
                    IDSector = Convert.ToInt32(objectivesRow[2].ToString()),
                    active = false,
                    requiedModuleTypes = requiedModuleTypesID
                };
                objectivesList.Add(objective);
            }
            objectiveListView.ItemsSource = null;
            objectiveListView.ItemsSource = objectivesList;
        }

        public void SetCharacteristicsToElements()
        {
            flightDurationTextBox.Text = characteristics.flightTime.ToString(); 
            frameWeightTextBox.Text = characteristics.frameWeight.ToString();
            speedTextBox.Text = characteristics.RPM.ToString();
            payloadTextBox.Text = characteristics.positiveLoad.ToString();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            characteristics.KV = 1000;
            jsonString = JsonSerializer.Serialize(characteristics);
            File.WriteAllText(JSONFILENAME, jsonString);
        }

        private void flightDurationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double value;
            var component = (TextBox)sender;
            if (component.Text != string.Empty)
            {
                if (double.TryParse(component.Text, out value))
                {
                    characteristics.flightTime = value;
                }
                else
                {
                    MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    component.Text = string.Empty;
                }
            }
        }

        private void frameWeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double value;
            var component = (TextBox)sender;
            if (component.Text != string.Empty)
            {
                if (double.TryParse(component.Text, out value))
                {
                    characteristics.frameWeight = value;
                }
                else
                {
                    MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    component.Text = string.Empty;
                }
            }
        }

        private void speedTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double value;
            var component = (TextBox)sender;
            if (component.Text != string.Empty)
            {
                if (double.TryParse(component.Text, out value))
                {
                    characteristics.RPM = value;
                }
                else
                {
                    MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    component.Text = string.Empty;
                }
            }
        }

        private void payloadTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            double value;
            var component = (TextBox)sender;
            if (component.Text != string.Empty)
            {
                if (double.TryParse(component.Text, out value))
                {
                    characteristics.positiveLoad = value;
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
            DroneComponentsWindow droneComponentsWindow = new DroneComponentsWindow(characteristics, dataBaseClass);
            droneComponentsWindow.ShowDialog();
            characteristics = droneComponentsWindow.characteristics;
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            droneComponentsClass.characteristics = characteristics;
            List<string> modules = new List<string>();
            foreach (DroneComponentsClass.ModuleType module in moduleListView.Items)
            {
                if (module.active)
                {
                    modules.Add(module.name);
                }
            }
            double modulesWeight = 0;
            foreach (string module in modules)
            {
                modulesWeight += Convert.ToDouble(dataBaseClass.GetCell($"Select МассаМодуля From Модуль Inner Join ТипМодуля on Модуль.ТипМодуля = ТипМодуля.IDТипаМодуля Where ТипМодуля.НаименованиеМодуля = '{module}'").ToString());
            }
            droneComponentsClass.characteristics.fullWeight = characteristics.positiveLoad*1000 + characteristics.frameWeight*1000 + modulesWeight + 100;
            droneComponentsClass.CalculateRequiedThrust();
            SelectionWindow selectionWindow = new SelectionWindow(droneComponentsClass, dataBaseClass, characteristics, modules);
            selectionWindow.ShowDialog();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            DroneComponentsClass.Objective objective = checkBox.DataContext as DroneComponentsClass.Objective;
            foreach (int moduleTypeID in objective.requiedModuleTypes)
            {
                moduleTypesList.Where(x => x.ID == moduleTypeID).ToList().ForEach(b => b.active = true);
            }
            moduleListView.ItemsSource = null;
            moduleListView.ItemsSource = moduleTypesList;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            DroneComponentsClass.Objective objective = checkBox.DataContext as DroneComponentsClass.Objective;
            foreach (int moduleTypeID in objective.requiedModuleTypes)
            {
                moduleTypesList.Where(x => x.ID == moduleTypeID).ToList().ForEach(b => b.active = false);
            }
            moduleListView.ItemsSource = null;
            moduleListView.ItemsSource = moduleTypesList;
        }

        private void droneListButton_Click(object sender, RoutedEventArgs e)
        {
            DroneListWindow droneListWindow = new DroneListWindow(dataBaseClass);
            droneListWindow.ShowDialog();
        }
    }
}
