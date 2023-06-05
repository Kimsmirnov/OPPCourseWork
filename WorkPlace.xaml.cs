using System;
using System.Collections.Generic;
using System.IO;
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
using OopCourseWork.Models;

namespace OopCourseWork
{
    /// <summary>
    /// Логика взаимодействия для WorkPlace.xaml
    /// </summary>
    public partial class WorkPlace : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public WorkPlace()
        {
            InitializeComponent();
            context = new OopCourseWork.Models.AppContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index) 
            {
                case 0:
                    using (var context = new OopCourseWork.Models.AppContext())
                    {
                        var accounts = context.Accaunts.ToList();
                        accountsDataGrid.ItemsSource = accounts;

                    }
                    break;
                case 1:
                    using (var context = new OopCourseWork.Models.AppContext())
                    {
                        var clients = context.clients.ToList();
                        accountsDataGrid.ItemsSource = clients;
                    }
                    break;
                case 2:
                    using (var context = new OopCourseWork.Models.AppContext())
                    {
                        var cars = context.cars.ToList();
                        accountsDataGrid.ItemsSource = cars; ;
                    }
                    break;
                case 3:
                    using (var context = new OopCourseWork.Models.AppContext())
                    {
                        var appointments = context.appointments.ToList();
                        accountsDataGrid.ItemsSource = appointments;
                    }
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseWindow chooseWindow = new ChooseWindow();
            chooseWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteMenu deleteMenu = new();
            deleteMenu.Show();
        }

        private void SortClients_Click(object sender, RoutedEventArgs e)
        {
            var sortedClients = context.clients.OrderBy(client => client.Name).ToList();
            accountsDataGrid.ItemsSource = sortedClients;

        }

        private void SortCars_Click(object sender, RoutedEventArgs e)
        {
            var sortedCars = context.cars.OrderBy(car => car.Mark).ToList();
            accountsDataGrid.ItemsSource = sortedCars;
        }

        private void SortAppoint_Click(object sender, RoutedEventArgs e)
        {
            var sortedAppointments = context.appointments.OrderBy(appointment => appointment.WorkType).ToList();
            accountsDataGrid.ItemsSource = sortedAppointments;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchID = searchInput.Text.Trim();
            bool clientfound = context.clients.Any(client => client.ID == searchID);
            bool carfound = context.cars.Any(car => car.CarID == searchID);
            bool appointmentfound = context.appointments.Any(appointment => appointment.AppointmentDate == searchID);

            if (clientfound) 
            {
                var user = context.clients.Single(client => client.ID == searchID);
                accountsDataGrid.ItemsSource = new List<Clients> { user };
            }
            else if (carfound) 
            {
                var car = context.cars.Single(car => car.CarID == searchID);
                accountsDataGrid.ItemsSource = new List<Cars> { car };
            }
            else if (appointmentfound)
            {
                var appoint = context.appointments.Single(appoint => appoint.AppointmentDate == searchID);
                accountsDataGrid.ItemsSource = new List<Appointments> { appoint };
            }
            else 
            {
                MessageBox.Show("Nothing Found!");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = accountsDataGrid.SelectedItem;
            UpdateSelectedItem(selectedItem);

        }

        private void UpdateSelectedItem(object selectedItem)
        {

            if (selectedItem is Clients)
            {
                var selectedClient = (Clients)selectedItem;
                context.clients.Update(selectedClient);
                context.SaveChanges();
            }
            else if (selectedItem is Cars)
            {
                var selectedCar = (Cars)selectedItem;
                context.cars.Update(selectedCar);
                context.SaveChanges();
            }
            else if (selectedItem is Appointments)
            {
                var selectedAppointment = (Appointments)selectedItem;
                context.appointments.Update(selectedAppointment);
                context.SaveChanges();
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            bool? response = saveFileDialog.ShowDialog();

            if (response == true) 
            {
                string filepath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filepath))
                    {
                        using (var context = new OopCourseWork.Models.AppContext())
                        {

                            var clients = context.clients.ToList();
                            writer.WriteLine("\nClients:");
                            foreach (var client in clients)
                            {
                                writer.WriteLine(client.Name + " " + client.Surname + " " + client.Email + " " + client.PhoneNum + " " + client.ID);
                            }

                            var cars = context.cars.ToList();
                            writer.WriteLine("\nCars:");
                            foreach (var car in cars)
                            {
                                writer.WriteLine(car.Mark + " " + car.Model + " " + car.Year + " " + car.CarID + " " + car.ClientID);
                            }

                            var appointments = context.appointments.ToList();
                            writer.WriteLine("\nAppointments:");
                            foreach (var appointment in appointments)
                            {
                                writer.WriteLine(appointment.AppointmentTime + " " + appointment.WorkType + " " + appointment.AppointmentDate + " " + appointment.ClientID + " " + appointment.CarID);
                            }
                        }
                    }

                    MessageBox.Show("Data saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}
