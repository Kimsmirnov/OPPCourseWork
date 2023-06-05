using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OopCourseWork.Models
{
    public class Cars
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        [Key]
        public string CarID { get; set; }
        public string ClientID { get; set; }

        public Cars() { }

        public Cars(string Mark, string Model, string Year, string CarID, string ClientID) 
        {
            this.Mark = Mark;
            this.Model = Model;
            this.Year = Year;
            this.CarID = CarID;
            this.ClientID = ClientID;
        }

    }
}
