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

    class ProdottoConfiguration : IEntityTypeConfiguration<Prodotto>
    {
        public void Configure(EntityTypeBuilder<Prodotto> builder)
        {
            builder.ToTable("Prodotto");
            builder.Property(c => c.Codice).IsFixedLength().HasMaxLength(5);
            builder.HasKey(k => k.Codice);
            builder.Property(c => c.Descrizione).IsRequired();
            builder.Property(c => c.Prezzo).IsRequired();
            builder.HasOne(r => r.Reparto).WithMany(p => p.Prodotti).HasForeignKey(k => k.RepartoNumero);

            //Per gestire la gerarchia
            builder.HasDiscriminator<string>("prodotto_type")
                   .HasValue<Prodotto>("prodotto")
                   .HasValue<ProdottoAlimentare>("alimentare")
                   .HasValue<ProdottoCasalingo>("casalingo");

            //con discriminante intero
            //builder.HasDiscriminator<int>("prodotto_type")
            //       .HasValue<Prodotto>(1)
            //       .HasValue<ProdottoAlimentare>(2)
            //       .HasValue<ProdottoCasalingo>(3);
        }
    }
}
