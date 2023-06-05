using OopCourseWork.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace OopCourseWork
{
    public partial class Registration : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public Registration()
        {
            InitializeComponent();
            context = new OopCourseWork.Models.AppContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = RegistrLoginInput.Text.Trim();
            string password = RegistrPasswordInput.Password.Trim();
            string password2 = SecondRegistrPasswordInput.Password.Trim();

            if (login.Length < 3)
            {
                RegistrLoginInput.ToolTip = "Login is too small!";
                RegistrLoginInput.BorderBrush = Brushes.DarkRed;
            }
            else if (password.Length < 5)
            {
                RegistrPasswordInput.ToolTip = "Password is too small!";
                RegistrPasswordInput.BorderBrush = Brushes.DarkRed;
            }
            else if (password.Length == 0)
            {
                RegistrPasswordInput.ToolTip = "Enter a Password!";
                RegistrPasswordInput.BorderBrush = Brushes.DarkRed;
            }
            else if (password2.Length == 0)
            {
                SecondRegistrPasswordInput.ToolTip = "Enter a Password!";
                SecondRegistrPasswordInput.BorderBrush = Brushes.DarkRed;
            }
            else if (password != password2)
            {
                SecondRegistrPasswordInput.ToolTip = "Password mismatch!";
                SecondRegistrPasswordInput.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                context.Accaunts.Add(new Accaunts() { Login = login, Password = password });
                context.SaveChanges();

                MBox mBox = new MBox();
                mBox.Show();

                this.Close();
            }
        }
    }
}
