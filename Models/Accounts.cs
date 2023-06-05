using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OopCourseWork.Models
{
    public class Accaunts
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }

        public Accaunts() { }

        public Accaunts(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
