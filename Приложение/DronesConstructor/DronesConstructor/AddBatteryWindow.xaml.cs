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

namespace DronesConstructor
{
    /// <summary>
    /// Логика взаимодействия для AddBatteryWindow.xaml
    /// </summary>
    public partial class AddBatteryWindow : Window
    {
        string mode = "add";
        public AddBatteryWindow(DataBaseClass dataBaseClass, int ID = -1)
        {
            InitializeComponent();
            if (ID >= 0)
            {
                DataRow dataRow = dataBaseClass.GetTable($"Select * From Батарея Where IDБатареи = {ID}").Rows[0];
                nameTextBox.Text = dataRow[1].ToString();
                capacityTextBox.Text = dataRow[2].ToString();
                dischargeTextBox.Text = dataRow[3].ToString();
                countOfCelssTextBox.Text = dataRow[4].ToString();
                weightTextBox.Text = dataRow[5].ToString();
                applyButton.Content = "Изменить";
                this.Title = "Изменение батареи";
                mode = "edit";
            }
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "add")
            {
                MessageBox.Show("Запись успешно сохранена");
            }
            else
            {
                MessageBox.Show("Запись успешно изменена");
            }
        }
    }
}
