using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.AgenziaViaggiEF.Models;

namespace Week6.AgenziaViaggiEF.Context
{
    public class PartecipanteConfiguration : IEntityTypeConfiguration<Partecipante>
    {
        public void Configure(EntityTypeBuilder<Partecipante> builder)
        {
            builder.ToTable("Partecipante");
            builder.HasKey(k => k.ID);
            builder.Property("Nome").IsRequired();
            builder.Property(c => c.Cognome).IsRequired();
            builder.Property(i => i.Indirizzo).HasMaxLength(50)
                                              .IsRequired();
            builder.Property(c => c.Citta).IsRequired();
            builder.Property(d => d.DataNascita).HasColumnType("datetime2")
                                                .IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50);

            builder.HasData(
               new Partecipante
               {
                   ID = 1,
                   Nome = "Mario",
                   Cognome = "Rossi",
                   DataNascita = new DateTime(1980, 1, 1),
                   Citta = "Milano",
                   Indirizzo = "Via dei faggi, 78"
               },
               new Partecipante
               {
                   ID = 2,
                   Nome = "Luca",
                   Cognome = "Verdi",
                   DataNascita = new DateTime(1990, 2, 2),
                   Citta = "Bologna",
                   Indirizzo = "Via dei ciliegi, 50"
               }
           );
        }
    }
}
