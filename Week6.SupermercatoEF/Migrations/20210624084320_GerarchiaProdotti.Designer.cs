﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week6.SupermercatoEF.Context;

namespace Week6.SupermercatoEF.Migrations
{
    [DbContext(typeof(SupermercatoContext))]
    [Migration("20210624084320_GerarchiaProdotti")]
    partial class GerarchiaProdotti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Dipendente", b =>
                {
                    b.Property<string>("Codice")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RepartoNumero")
                        .HasColumnType("int");

                    b.HasKey("Codice");

                    b.HasIndex("RepartoNumero");

                    b.ToTable("Dipendente");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Prodotto", b =>
                {
                    b.Property<string>("Codice")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepartoNumero")
                        .HasColumnType("int");

                    b.Property<string>("prodotto_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codice");

                    b.HasIndex("RepartoNumero");

                    b.ToTable("Prodotto");

                    b.HasDiscriminator<string>("prodotto_type").HasValue("prodotto");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Reparto", b =>
                {
                    b.Property<int>("NumeroReparto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumeroReparto");

                    b.ToTable("Reparto");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Vendita", b =>
                {
                    b.Property<int>("NumeroVendita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodiceProdotto")
                        .HasColumnType("nchar(5)");

                    b.Property<DateTime>("DataVendita")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantita")
                        .HasColumnType("int");

                    b.HasKey("NumeroVendita");

                    b.HasIndex("CodiceProdotto");

                    b.ToTable("Vendita");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.ProdottoAlimentare", b =>
                {
                    b.HasBaseType("Week6.SupermercatoEF.Models.Prodotto");

                    b.Property<DateTime>("DataScadenza")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("alimentare");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.ProdottoCasalingo", b =>
                {
                    b.HasBaseType("Week6.SupermercatoEF.Models.Prodotto");

                    b.Property<string>("Marchio")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("casalingo");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Dipendente", b =>
                {
                    b.HasOne("Week6.SupermercatoEF.Models.Reparto", "Reparto")
                        .WithMany("Dipendenti")
                        .HasForeignKey("RepartoNumero");

                    b.Navigation("Reparto");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Prodotto", b =>
                {
                    b.HasOne("Week6.SupermercatoEF.Models.Reparto", "Reparto")
                        .WithMany("Prodotti")
                        .HasForeignKey("RepartoNumero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reparto");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Vendita", b =>
                {
                    b.HasOne("Week6.SupermercatoEF.Models.Prodotto", "Prodotto")
                        .WithMany("Vendite")
                        .HasForeignKey("CodiceProdotto");

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Prodotto", b =>
                {
                    b.Navigation("Vendite");
                });

            modelBuilder.Entity("Week6.SupermercatoEF.Models.Reparto", b =>
                {
                    b.Navigation("Dipendenti");

                    b.Navigation("Prodotti");
                });
#pragma warning restore 612, 618
        }
    }
}
