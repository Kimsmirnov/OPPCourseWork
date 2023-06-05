using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OopCourseWork.Models
{
    public class Appointments
    {       
        public string AppointmentTime { get; set; }
        public string WorkType { get; set; }
        [Key]
        public string AppointmentDate { get; set; }
        public string ClientID { get; set; }
        public string CarID { get; set; }

        public Appointments() { }

        public Appointments(string AppointmentTime, string WorkType, string AppointmentDate, string ClientID, string CarID) 
        {
            this.AppointmentTime = AppointmentTime;
            this.WorkType = WorkType;
            this.AppointmentDate = AppointmentDate;
            this.ClientID = ClientID;
            this.CarID = CarID;
        }
    }
}
