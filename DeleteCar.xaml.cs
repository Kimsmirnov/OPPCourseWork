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
    /// Логика взаимодействия для DeleteCar.xaml
    /// </summary>
    public partial class DeleteCar : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public DeleteCar()
        {
            InitializeComponent();
            context = new OopCourseWork.Models.AppContext();
        }

        private void RemoveClient(string carID)
        {
            using (var context = new Models.AppContext())
            {
                try
                {
                    var car = context.cars.FirstOrDefault(c => c.CarID == carID);
                    if (car != null)
                    {
                        context.cars.Remove(car);
                        context.SaveChanges();
                        MessageBox.Show("Car successfully deleted!");
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("Befor Deleting Car you should Delete Appointment with this car!");
                }
            }
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            string ID = IDforDeletion.Text;
            RemoveClient(ID);

            this.Close();
        }
    }
}
