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
using OopCourseWork.Models;

namespace OopCourseWork
{
    public partial class DeleteClient : Window
    {
        private readonly OopCourseWork.Models.AppContext context;

        public DeleteClient()
        {
            InitializeComponent();
            context = new OopCourseWork.Models.AppContext();
        }

        private void RemoveClient(string clientID)
        {
            using (var context = new Models.AppContext())
            {
                try
                {
                    var client = context.clients.FirstOrDefault(c => c.ID == clientID);
                    if (client != null)
                    {
                        context.clients.Remove(client);
                        context.SaveChanges();
                        MessageBox.Show("Client successfully deleted!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Befor Deleting Client you should Delete Car and Appointment with this client!");
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
