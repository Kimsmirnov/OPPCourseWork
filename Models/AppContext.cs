using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OopCourseWork.Models;
using System.IO;
using System.Reflection;


namespace OopCourseWork.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Accaunts> Accaunts { get; set; }
        public DbSet<Clients> clients { get; set; }
        public DbSet<Cars> cars { get; set; }
        public DbSet<Appointments> appointments { get; set; }

        public string path = @"C:\Users\snapa\OneDrive\Рабочий стол\CarServiceDB.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source = {path}");

    }
}
