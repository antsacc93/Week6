using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Models;

namespace Week6.SupermercatoEF.Context
{
    public class DipendenteConfiguration : IEntityTypeConfiguration<Dipendente>
    {
        public void Configure(EntityTypeBuilder<Dipendente> builder)
        {
            builder.ToTable("Dipendente");
            builder.Property(c => c.Codice).IsFixedLength().HasMaxLength(5);
            builder.HasKey(k => k.Codice);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Cognome).IsRequired();
            builder.Property(c => c.DataNascita).IsRequired();
            

            builder.HasOne(r => r.Reparto).WithMany(p => p.Dipendenti).HasForeignKey(k => k.RepartoNumero);
        }
    }
}
