using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AppointmentAdd.xaml
    /// </summary>
    public partial class AppointmentAdd : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public AppointmentAdd()
        {
            InitializeComponent();
            context = new OopCourseWork.Models.AppContext();
        }

        private bool IsStringValid(string line)
        {
            return !string.IsNullOrEmpty(line) && line.All(c => Char.IsLetter(c));
        }

        private bool IsNumberValid(string number)
        {
            return number.All(char.IsDigit);
        }

        private bool IsTimeValid(string time)
        {
            // Define the regular expression pattern for the time format
            string pattern = @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$";

            // Check if the time matches the pattern
            return Regex.IsMatch(time, pattern);
        }

        private bool IsDateValid(string date)
        {
            // Define the expected date format
            string format = "dd/MM/yyyy";

            // Try parsing the date input using the specified format
            if (DateTime.TryParseExact(date, format, null, DateTimeStyles.None, out DateTime parsedDate))
            {
                // Date input is valid
                return true;
            }
            else
            {
                // Date input is invalid
                return false;
            }
        }

        private bool IsWorkTypeValid(string workType)
        {
            string[] validWorkTypes = { "Tire Change", "Repair Work", "Technical Review", "Painting Work" };

            return validWorkTypes.Contains(workType);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            string Time = AppointmentTime.Text.Trim();
            string Work = WorkType.Text.Trim();
            string Date = AppointmentDate.Text.Trim();
            string CarId = CarID.Text.Trim();
            string ClientId = ClientID.Text.Trim();

            bool userfound = context.clients.Any(client => client.ID == ClientId);
            bool carfound = context.cars.Any(car => car.CarID == CarId);

            if (!IsTimeValid(Time))
            {
                AppointmentTime.ToolTip = "Incorrect Time format.";
                AppointmentTime.BorderBrush = Brushes.DarkRed;
            }
            else if (!IsWorkTypeValid(Work)) 
            {
                WorkType.ToolTip = "Incorrect Work Type, be sure that you Enter (Tire Change, Repair Work, Technical Review, Painting Work).";
                WorkType.BorderBrush = Brushes.DarkRed;
            }
            else if (!IsDateValid(Date)) 
            {
                AppointmentDate.ToolTip = "Incorrect Date format.";
                AppointmentDate.BorderBrush = Brushes.DarkRed;
            }
            else if (!carfound) 
            {
                CarID.ToolTip = "Car ID not Found!";
                CarID.BorderBrush = Brushes.DarkRed;
            }
            else if (!userfound)
            {
                ClientID.ToolTip = "Client ID not Found!";
                ClientID.BorderBrush = Brushes.DarkRed;
            }
            else 
            {
                MessageBox.Show("Appointment successfully added!");
                context.appointments.Add(new() { AppointmentTime = Time, WorkType = Work, AppointmentDate = Date, CarID = CarId, ClientID = ClientId });
                context.SaveChanges();

                this.Close();
            }

        }
    }
}
