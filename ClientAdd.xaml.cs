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
    /// Логика взаимодействия для ClientAdd.xaml
    /// </summary>
    public partial class ClientAdd : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public ClientAdd()
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
            string Name = ClientName.Text.Trim();
            string Surname = ClientSurname.Text.Trim();
            string Email = ClientEmail.Text.Trim();
            string PhoneNum = ClientPhoneNum.Text.Trim();
            string ID = ClientID.Text.Trim();

            if (Name.Length < 1 || !(IsStringValid(Name)))
            {
                ClientName.ToolTip = "Name should contein only letters or Name is empty.";
                ClientName.BorderBrush = Brushes.DarkRed;
            }
            else if (Surname.Length < 1 || !(IsStringValid(Surname))) 
            {
                ClientSurname.ToolTip = "Surname should contein only letters or Surname is empty.";
                ClientSurname.BorderBrush = Brushes.DarkRed;
            }
            else if (Email.Length < 1 || !(Email.Contains("@")) || !(Email.Contains(".")))
            {
                ClientEmail.ToolTip = "Incorrect Email or Email is empty.";
                ClientEmail.BorderBrush = Brushes.DarkRed;
            }
            else if (PhoneNum.Length < 8 || !(IsNumberValid(PhoneNum))) 
            {
                ClientPhoneNum.ToolTip = "Incorrect Phone Number or Number is too small.";
                ClientPhoneNum.BorderBrush = Brushes.DarkRed;
            }
            else if (ID.Length < 5 || !(IsNumberValid(ID))) 
            {
                ClientID.ToolTip = "Incorrect ID or ID is too small.";
                ClientID.BorderBrush = Brushes.DarkRed;
            }
            else if (context.clients.Any(c => c.Email == Email))
            {
                ClientEmail.ToolTip = "Email already exists.";
                ClientEmail.BorderBrush = Brushes.DarkRed;
            }
            else if (context.clients.Any(c => c.PhoneNum == PhoneNum))
            {
                ClientPhoneNum.ToolTip = "Phone Number already exists.";
                ClientPhoneNum.BorderBrush = Brushes.DarkRed;
            }
            else if (context.clients.Any(c => c.ID == ID))
            {
                ClientID.ToolTip = "ID already exists.";
                ClientID.BorderBrush = Brushes.DarkRed;
            }
            else 
            {           
                context.clients.Add(new () { Name = Name, Surname = Surname, Email = Email, PhoneNum = PhoneNum, ID = ID });
                context.SaveChanges();

                this.Close();
                MessageBox.Show("Client successfully added!");
            }

        }
    }
}
