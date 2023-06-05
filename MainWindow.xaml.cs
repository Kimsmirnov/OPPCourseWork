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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OopCourseWork.Models;

namespace OopCourseWork
{

    public partial class MainWindow : Window
    {
        //List<Accounts> _account = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new();
            registration.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var Username = LoginInput.Text;
            var Password = PasswordInput.Password;

            using (Models.AppContext context = new Models.AppContext())
            {
                bool userfound = context.Accaunts.Any(user => user.Login == Username && user.Password == Password);

                if (userfound)
                {
                    WorkPlace place = new();
                    place.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Wrong Input Data!{Environment.NewLine} Please Try Again.");
                }
            }

            //var result = _account.Select(x => x).Where(c => c.Login == LoginInput.Text && c.Password == PasswordInput.Password).ToList();
            // if (result.Any())
            //{
            //   WorkPlace place = new();
            //   place.Show();
            //   this.Close();
            // }
            //else 
            //{
            //   MessageBox.Show($"Wrong Input Data!{Environment.NewLine} Please Try Again.");
            //}
        }
    }
}
