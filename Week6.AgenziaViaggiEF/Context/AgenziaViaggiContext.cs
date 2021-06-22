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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Partecipante
            modelBuilder.Entity<Partecipante>().ToTable("Partecipante");
            modelBuilder.Entity<Partecipante>().HasKey(k => k.ID);
            modelBuilder.Entity<Partecipante>().Property("Nome").IsRequired();
            modelBuilder.Entity<Partecipante>().Property(c => c.Cognome).IsRequired();
            modelBuilder.Entity<Partecipante>().Property(i => i.Indirizzo)
                                                .HasMaxLength(50)
                                                .IsRequired();
            modelBuilder.Entity<Partecipante>().Property(c => c.Citta).IsRequired();
            modelBuilder.Entity<Partecipante>().Property(d => d.DataNascita)
                                               .HasColumnType("datetime2")
                                               .IsRequired();


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
                                       //.Map(gp => { 
                                       //     gp.MapLeftKey("GitaRefID"),
                                       //     gp.MapRighyKey("PartecipanteRefID"),
                                       //     gp.ToTable("GitaPartecipante")
                                       //});



        } 

    }
}
