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

namespace OopCourseWork
{
    /// <summary>
    /// Логика взаимодействия для DeleteMenu.xaml
    /// </summary>
    public partial class DeleteMenu : Window
    {
        public DeleteMenu()
        {
            InitializeComponent();
        }

        private void ClientDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteClient deleteClient = new();
            deleteClient.Show();

            this.Close();
        }

        private void CarDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteCar deleteCar = new();
            deleteCar.Show();

            this.Close();
        }

        private void AppointmentDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteAppoint deleteAppoint = new();
            deleteAppoint.Show();

            this.Close();
        }
    }
}
