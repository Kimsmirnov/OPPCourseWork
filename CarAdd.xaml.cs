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
    /// Логика взаимодействия для CarAdd.xaml
    /// </summary>
    public partial class CarAdd : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public CarAdd()
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            string Mark = CarMark.Text.Trim();
            string Model = CarModel.Text.Trim();
            string Year = CarYear.Text.Trim();
            string CarId = CarID.Text.Trim();
            string ClientId = ClientID.Text.Trim();

            bool userfound = context.clients.Any(client => client.ID == ClientId);

            if (Mark.Length < 1 || !(IsStringValid(Mark)))
            {
                CarMark.ToolTip = "Mark should contein only letters or Mark is empty.";
                CarMark.BorderBrush = Brushes.DarkRed;
            }
            else if (Model.Length < 1)
            {
                CarModel.ToolTip = "Model is empty.";
                CarModel.BorderBrush = Brushes.DarkRed;
            }
            else if (Year.Length < 4 || Year.Length < 1 || !(IsNumberValid(Year)))
            {
                CarYear.ToolTip = "Year is empty or too small. Year should contein only numbers.";
                CarYear.BorderBrush = Brushes.DarkRed;
            }
            else if (!(userfound)) 
            {
                ClientID.ToolTip = "Client not Found!.";
                ClientID.BorderBrush = Brushes.DarkRed;
            }
            else if (CarId.Length < 1) 
            {
                CarID.ToolTip = "CarID is empty.";
                CarID.BorderBrush = Brushes.DarkRed;
            }
            else if (context.cars.Any(c => c.CarID == CarId))
            {
                CarID.ToolTip = "ID already exists.";
                CarID.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                MessageBox.Show("Car successfully added!");
                context.cars.Add(new() { Mark = Mark, Model = Model, Year = Year, CarID = CarId, ClientID = ClientId });
                context.SaveChanges();

                this.Close();
            }
        }
    }
}
