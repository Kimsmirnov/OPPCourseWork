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
    /// Логика взаимодействия для DeleteAppoint.xaml
    /// </summary>
    public partial class DeleteAppoint : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public DeleteAppoint()
        {
            InitializeComponent();
            context = new OopCourseWork.Models.AppContext();
        }

        private void RemoveAppoint(string appointDate)
        {
            using (var context = new Models.AppContext())
            {
                var appoint = context.appointments.FirstOrDefault(c => c.AppointmentDate == appointDate);
                if (appoint != null)
                {
                    MessageBox.Show("Appointment successfully deleted!");
                    context.appointments.Remove(appoint);
                    context.SaveChanges();
                }
            }
        }

        private void DeletButton_Click(object sender, RoutedEventArgs e)
        {
            string date = IDforDeletion.Text;
            RemoveAppoint(date);

            this.Close();
        }
    }
}
