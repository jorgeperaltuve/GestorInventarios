using System;
using GestorInventario.model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorInventario.model.Context
{
    public partial class GestorInventariosContext : DbContext
    {
        public GestorInventariosContext()
        {
        }

        public GestorInventariosContext(DbContextOptions<GestorInventariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Elemento> Elemento { get; set; }
        public virtual DbSet<TipoElemento> TipoElemento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-RNFSP8K3\\DESARROLLO;Database=GestorInventarios; User ID=Jorge;Password=12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Elemento>(entity =>
            {
                entity.Property(e => e.ElementoId).HasColumnName("ElementoID");

                entity.Property(e => e.Disponible)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoElementoId).HasColumnName("TipoElementoID");

                entity.HasOne(d => d.TipoElemento)
                    .WithMany(p => p.Elemento)
                    .HasForeignKey(d => d.TipoElementoId)
                    .HasConstraintName("FK_Elemento_TipoElemento");
            });

            modelBuilder.Entity<TipoElemento>(entity =>
            {
                entity.Property(e => e.TipoElementoId).HasColumnName("TipoElementoID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAcceso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
