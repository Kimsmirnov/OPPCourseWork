using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OopCourseWork.Models
{
    public class Clients
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        [Key]
        public string ID { get; set; }

        public Clients() { }

        public Clients(string Name, string Surname, string Email, string PhoneNum, string ID) 
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.PhoneNum = PhoneNum;
            this.ID = ID;
        }
    }
}
