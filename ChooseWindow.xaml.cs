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
    /// Логика взаимодействия для ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
        public ChooseWindow()
        {
            InitializeComponent();
        }

        private void ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            ClientAdd clientAdd = new();
            clientAdd.Show();

            this.Close();
        }

        private void CarAdd_Click(object sender, RoutedEventArgs e)
        {
            CarAdd carAdd = new();
            carAdd.Show();

            this.Close();
        }

        private void AppointmentAdd_Click(object sender, RoutedEventArgs e)
        {
            AppointmentAdd appointmentAdd = new();
            appointmentAdd.Show();

            this.Close();
        }
    }
}
