using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Week6.PrimoProgettoEF.Entities
{
    public partial class RegistroEsamiContext : DbContext
    {
        public RegistroEsamiContext()
        {
        }

        public RegistroEsamiContext(DbContextOptions<RegistroEsamiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Esame> Esames { get; set; }
        public virtual DbSet<Studente> Studentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Initial Catalog = RegistroEsami; Persist Security Info = False; Integrated Security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Esame>(entity =>
            {
                entity.ToTable("Esame");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cfu).HasColumnName("CFU");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StudenteId).HasColumnName("StudenteID");

                entity.HasOne(d => d.Studente)
                    .WithMany(p => p.Esames)
                    .HasForeignKey(d => d.StudenteId)
                    .HasConstraintName("FK__Esame__StudenteI__3C69FB99");
            });

            modelBuilder.Entity<Studente>(entity =>
            {
                entity.ToTable("Studente");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cognome)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascita).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
