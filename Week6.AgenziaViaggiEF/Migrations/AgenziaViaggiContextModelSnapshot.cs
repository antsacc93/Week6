﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week6.AgenziaViaggiEF.Context;

namespace Week6.AgenziaViaggiEF.Migrations
{
    [DbContext(typeof(AgenziaViaggiContext))]
    partial class AgenziaViaggiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GitaPartecipante", b =>
                {
                    b.Property<int>("GiteID")
                        .HasColumnType("int");

                    b.Property<int>("PartecipantiID")
                        .HasColumnType("int");

                    b.HasKey("GiteID", "PartecipantiID");

                    b.HasIndex("PartecipantiID");

                    b.ToTable("GitaPartecipante");
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Gita", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPartenza")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItinerarioID")
                        .HasColumnType("int");

                    b.Property<int>("ResponsabileID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ItinerarioID");

                    b.HasIndex("ResponsabileID");

                    b.ToTable("Gita");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DataPartenza = new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ItinerarioID = 1,
                            ResponsabileID = 1
                        });
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Itinerario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Itinerario");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Descrizione = "Viaggio a Londra",
                            Durata = 15,
                            Prezzo = 500.79998779296875
                        });
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Partecipante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Partecipante");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Citta = "Milano",
                            Cognome = "Rossi",
                            DataNascita = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indirizzo = "Via dei faggi, 78",
                            Nome = "Mario"
                        },
                        new
                        {
                            ID = 2,
                            Citta = "Bologna",
                            Cognome = "Verdi",
                            DataNascita = new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Indirizzo = "Via dei ciliegi, 50",
                            Nome = "Luca"
                        });
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Responsabile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.HasKey("ID");

                    b.ToTable("Responsabile");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Cognome = "Bianchi",
                            Nome = "Roberta",
                            Telefono = "3334445556"
                        });
                });

            modelBuilder.Entity("GitaPartecipante", b =>
                {
                    b.HasOne("Week6.AgenziaViaggiEF.Models.Gita", null)
                        .WithMany()
                        .HasForeignKey("GiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Week6.AgenziaViaggiEF.Models.Partecipante", null)
                        .WithMany()
                        .HasForeignKey("PartecipantiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Gita", b =>
                {
                    b.HasOne("Week6.AgenziaViaggiEF.Models.Itinerario", "Itinerario")
                        .WithMany("Gite")
                        .HasForeignKey("ItinerarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Week6.AgenziaViaggiEF.Models.Responsabile", "Responsabile")
                        .WithMany("Gite")
                        .HasForeignKey("ResponsabileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itinerario");

                    b.Navigation("Responsabile");
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Itinerario", b =>
                {
                    b.Navigation("Gite");
                });

            modelBuilder.Entity("Week6.AgenziaViaggiEF.Models.Responsabile", b =>
                {
                    b.Navigation("Gite");
                });
#pragma warning restore 612, 618
        }
    }
}
