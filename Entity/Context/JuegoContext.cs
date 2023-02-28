using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity.Entities.Juego;

#nullable disable

namespace Entity.Context
{
    public partial class JuegoContext : DbContext
    {
        public JuegoContext()
        {
        }

        public JuegoContext(DbContextOptions<JuegoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Dificultad> Dificultads { get; set; }
        public virtual DbSet<Juego> Juegos { get; set; }
        public virtual DbSet<Jugador> Jugadors { get; set; }
        public virtual DbSet<Penalizacion> Penalizacions { get; set; }
        public virtual DbSet<Preguntum> Pregunta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=127.0.0.1:1521/orcl;User Id=JUEGO;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JUEGO");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("SYS_C0010743");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.IdCategoria)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIA");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("'A' ");
            });

            modelBuilder.Entity<Dificultad>(entity =>
            {
                entity.HasKey(e => e.IdDificultad)
                    .HasName("SYS_C0010747");

                entity.ToTable("DIFICULTAD");

                entity.Property(e => e.IdDificultad)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_DIFICULTAD");

                entity.Property(e => e.Dificultad1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIFICULTAD");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("'A' ");
            });

            modelBuilder.Entity<Juego>(entity =>
            {
                entity.HasKey(e => e.IdJuego)
                    .HasName("SYS_C0010772");

                entity.ToTable("JUEGO");

                entity.Property(e => e.IdJuego)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_JUEGO");

                entity.Property(e => e.FechaJuego)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_JUEGO")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.IdJugador)
                    .HasPrecision(6)
                    .HasColumnName("ID_JUGADOR");

                entity.Property(e => e.Puntaje)
                    .HasPrecision(6)
                    .HasColumnName("PUNTAJE");

                entity.HasOne(d => d.IdJugadorNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JUEGO_JUGADOR");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador)
                    .HasName("SYS_C0010767");

                entity.ToTable("JUGADOR");

                entity.Property(e => e.IdJugador)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_JUGADOR");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("'A' ");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Penalizacion>(entity =>
            {
                entity.HasKey(e => e.IdPenalizacion)
                    .HasName("SYS_C0010762");

                entity.ToTable("PENALIZACION");

                entity.Property(e => e.IdPenalizacion)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PENALIZACION");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("'A' ");

                entity.Property(e => e.IdDificultad)
                    .HasPrecision(6)
                    .HasColumnName("ID_DIFICULTAD");

                entity.Property(e => e.Penalizacion1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PENALIZACION");

                entity.HasOne(d => d.IdDificultadNavigation)
                    .WithMany(p => p.Penalizacions)
                    .HasForeignKey(d => d.IdDificultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PENALIZACION_DIFICULTAD");
            });

            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                    .HasName("SYS_C0010755");

                entity.ToTable("PREGUNTA");

                entity.Property(e => e.IdPregunta)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PREGUNTA");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("'A' ");

                entity.Property(e => e.IdCategoria)
                    .HasPrecision(6)
                    .HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.IdDificultad)
                    .HasPrecision(6)
                    .HasColumnName("ID_DIFICULTAD");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PREGUNTA");

                entity.Property(e => e.Puntos)
                    .HasPrecision(6)
                    .HasColumnName("PUNTOS");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESPUESTA");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PREGUNTA_CATEGORIA");

                entity.HasOne(d => d.IdDificultadNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdDificultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PREGUNTA_DIFICULTAD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
