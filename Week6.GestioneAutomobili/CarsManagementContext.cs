using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.GestioneAutomobili.Models;

namespace Week6.GestioneAutomobili
{
    public class CarsManagementContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }

        public CarsManagementContext () : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = CarsManagement; Server = .\SQLEXPRESS");
        }
    }
}
