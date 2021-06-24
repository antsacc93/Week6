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
    public class RepartoConfiguration : IEntityTypeConfiguration<Reparto>
    {
        public void Configure(EntityTypeBuilder<Reparto> builder)
        {
            builder.ToTable("Reparto");
            builder.HasKey(k => k.NumeroReparto);
            builder.Property(c => c.Nome).IsRequired();
            
            
        }
    }
}
