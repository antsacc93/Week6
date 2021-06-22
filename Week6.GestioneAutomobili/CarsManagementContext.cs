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
                                    Initial Catalog = CarsManagement2; Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person").HasKey(p => p.CF);
            modelBuilder.Entity<Person>().Property(p => p.CF).HasMaxLength(16).IsFixedLength();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.DateOfBirth)
                                         .HasColumnName("Birthday")
                                         .IsRequired();

            modelBuilder.Entity<Car>().ToTable("Car").HasKey(c => c.Plate);
            modelBuilder.Entity<Car>().Property("RegistrationDate")
                                      .HasColumnName("RegDate")
                                      .HasColumnType("datetime2")
                                      .IsRequired();
            modelBuilder.Entity<Car>().Property("NumSeats").IsRequired();
            modelBuilder.Entity<Car>().Property("Brand").IsRequired();
            modelBuilder.Entity<Car>().HasOne(p => p.Person)
                                      .WithMany(c => c.Cars)
                                      .HasForeignKey(p => p.CFPerson);
        }
    }
}
