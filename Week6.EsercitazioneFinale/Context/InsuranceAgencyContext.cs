using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercitazioneFinale.Models;

namespace Week6.EsercitazioneFinale.Context
{
    public class InsuranceAgencyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsurancePolicy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; 
                                    Integrated Security = true; 
                                    Initial Catalog = InsuranceAgency; 
                                    Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .ToTable("Customer")
                        .HasKey(c => c.TaxCode);
            modelBuilder.Entity<Customer>()
                        .Property(c => c.TaxCode).IsFixedLength().HasMaxLength(16);
            modelBuilder.Entity<Customer>()
                        .Property(c => c.FirstName).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Customer>()
                        .Property(c => c.LastName).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Customer>()
                        .Property(c => c.Address).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<InsurancePolicy>()
                        .ToTable("Policy")
                        .HasKey(p => p.Number);
            modelBuilder.Entity<InsurancePolicy>()
                        .Property(p => p.StipulationDate)
                        .HasColumnType("datetime2")
                        .HasColumnName("Date")
                        .IsRequired();
            modelBuilder.Entity<InsurancePolicy>()
                        .Property(p => p.InsuredAmount)
                        .IsRequired();
            modelBuilder.Entity<InsurancePolicy>()
                        .Property(p => p.MonthlyRate)
                        .IsRequired();
            modelBuilder.Entity<InsurancePolicy>()
                        .HasOne(p => p.Customer)
                        .WithMany(c => c.Policies)
                        .HasForeignKey(p => p.CustomerCode);

            modelBuilder.Entity<InsurancePolicy>()
                        .HasDiscriminator<string>("PolicyType")
                        .HasValue<CarInsurance>("CarInsurance")
                        .HasValue<TheftInsurance>("TheftInsurance")
                        .HasValue<LifeInsurance>("LifeInsurance");

            modelBuilder.Entity<Customer>()
                        .HasData(
                            new Customer
                            {
                                TaxCode = "RSSMRA80D23T123P",
                                FirstName = "Maria",
                                LastName = "Rossi",
                                Address = "Via della vittoria, 67 Milano (MI)"
                            },
                            new Customer
                            {
                                TaxCode = "SCCNTN93C56T345W",
                                FirstName = "Antonia",
                                LastName = "Sacchitella",
                                Address = "Via D'annunzio 7"
                            }
                );
            modelBuilder.Entity<CarInsurance>().HasData(
                    new CarInsurance()
                    {
                        Number = 1,
                        StipulationDate = DateTime.Today,
                        InsuredAmount = 2000,
                        MonthlyRate = 50,
                        Plate = "PP123",
                        Displacement = 2500,
                        CustomerCode = "RSSMRA80D23T123P"
                    }
                );
        }

    }
}
