using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.AgenziaViaggiEF.Models;

namespace Week6.AgenziaViaggiEF.Context
{
    public class AgenziaViaggiContext : DbContext
    {
        public DbSet<Partecipante> Partecipanti { get; set; }
        public DbSet<Responsabile> Responsabili { get; set; }
        public DbSet<Itinerario> Itinerari { get; set; }
        public DbSet<Gita> Gite { get; set; }

        public AgenziaViaggiContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = AgenziaViaggi3; Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Partecipante
            //modelBuilder.Entity<Partecipante>().ToTable("Partecipante");
            //modelBuilder.Entity<Partecipante>().HasKey(k => k.ID);
            //modelBuilder.Entity<Partecipante>().Property("Nome").IsRequired();
            //modelBuilder.Entity<Partecipante>().Property(c => c.Cognome).IsRequired();
            //modelBuilder.Entity<Partecipante>().Property(i => i.Indirizzo)
            //                                    .HasMaxLength(50)
            //                                    .IsRequired();
            //modelBuilder.Entity<Partecipante>().Property(c => c.Citta).IsRequired();
            //modelBuilder.Entity<Partecipante>().Property(d => d.DataNascita)
            //                                   .HasColumnType("datetime2")
            //                                   .IsRequired();
            modelBuilder.ApplyConfiguration<Partecipante>(new PartecipanteConfiguration());


            //Responsabile
            modelBuilder.Entity<Responsabile>().ToTable("Responsabile")
                                                .HasKey(k => k.ID);
            modelBuilder.Entity<Responsabile>().Property("Nome").IsRequired();
            modelBuilder.Entity<Responsabile>().Property("Cognome").IsRequired();
            modelBuilder.Entity<Responsabile>().Property("Telefono")
                                               .IsFixedLength()
                                               .HasMaxLength(10)
                                               .IsRequired();

            //Itinerario
            modelBuilder.Entity<Itinerario>().ToTable("Itinerario").HasKey(k => k.ID);
            modelBuilder.Entity<Itinerario>().Property("Descrizione").HasMaxLength(120).IsRequired();
            modelBuilder.Entity<Itinerario>().Property("Durata").IsRequired();
            modelBuilder.Entity<Itinerario>().Property(p => p.Prezzo)
                                             .HasColumnType("float")
                                             .IsRequired();

            //Gita
            modelBuilder.Entity<Gita>().ToTable("Gita").HasKey(k => k.ID);
            modelBuilder.Entity<Gita>().Property("DataPartenza")
                                       .HasColumnType("datetime2")
                                       .IsRequired();
            modelBuilder.Entity<Gita>().HasOne(r => r.Responsabile) //navigation property
                                       .WithMany(g => g.Gite) // collection corrispondente in responsabile
                                       .HasForeignKey(f => f.ResponsabileID); //non necessario se rispetto le convenzioni di EF

            modelBuilder.Entity<Gita>().HasOne(i => i.Itinerario)
                                       .WithMany(g => g.Gite)
                                       .HasForeignKey(i => i.ItinerarioID);
            modelBuilder.Entity<Gita>().HasMany(p => p.Partecipanti)
                                       .WithMany(g => g.Gite);


            //modelBuilder.Entity<GitaPartecipante>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            //modelBuilder.Entity<GitaPartecipante>()
            //.HasOne<Gita>(g => g.Partecipanti)
            //.WithMany(p => p.Partecipanti)
            //.HasForeignKey(sc => sc.CId);

            //Pre-caricamento dei dati
            //modelBuilder.Entity<Partecipante>().HasData(
            //    new Partecipante
            //    {
            //        ID = 1,
            //        Nome = "Mario",
            //        Cognome = "Rossi",
            //        DataNascita = new DateTime(1980, 1, 1),
            //        Citta = "Milano",
            //        Indirizzo = "Via dei faggi, 78"
            //    },
            //    new Partecipante
            //    {
            //        ID = 2,
            //        Nome = "Luca",
            //        Cognome = "Verdi",
            //        DataNascita = new DateTime(1990, 2, 2),
            //        Citta = "Bologna",
            //        Indirizzo = "Via dei ciliegi, 50"
            //    }
            //);
            modelBuilder.Entity<Itinerario>().HasData(
                new Itinerario
                {
                    ID = 1,
                    Descrizione = "Viaggio a Londra",
                    Durata = 15,
                    Prezzo = 500.80f
                }
            );
            modelBuilder.Entity<Responsabile>().HasData(
                new Responsabile
                {
                    ID = 1,
                    Nome = "Roberta",
                    Cognome = "Bianchi",
                    Telefono = "3334445556"
                }
            );

            modelBuilder.Entity<Gita>().HasData(
                new Gita
                {
                    ID = 1,
                    DataPartenza = new DateTime(2021, 06, 22),
                    ItinerarioID = 1,
                    ResponsabileID = 1
                }
            );


        } 

    }
}
