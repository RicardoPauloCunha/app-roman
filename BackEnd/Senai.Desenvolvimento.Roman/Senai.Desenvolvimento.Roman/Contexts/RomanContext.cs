using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Equipes> Equipes { get; set; }
        public virtual DbSet<Professores> Professores { get; set; }
        public virtual DbSet<Projetos> Projetos { get; set; }
        public virtual DbSet<Temas> Temas { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.PROFESSOR_EQUIPE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PROFESSOR_PROJETO'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog = ROMAN;user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradores>(entity =>
            {
                entity.HasKey(e => e.AdministradorId);

                entity.ToTable("ADMINISTRADORES");

                entity.Property(e => e.AdministradorId).HasColumnName("ADMINISTRADOR_ID");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administradores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__ADMINISTR__ID_US__534D60F1");
            });

            modelBuilder.Entity<Equipes>(entity =>
            {
                entity.HasKey(e => e.EquipeId);

                entity.ToTable("EQUIPES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__EQUIPES__E2AB1FF45B02940E")
                    .IsUnique();

                entity.Property(e => e.EquipeId).HasColumnName("EQUIPE_ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professores>(entity =>
            {
                entity.HasKey(e => e.ProfessorId);

                entity.ToTable("PROFESSORES");

                entity.Property(e => e.ProfessorId).HasColumnName("PROFESSOR_ID");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Professores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PROFESSOR__ID_US__5070F446");
            });

            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.HasKey(e => e.ProjetoId);

                entity.ToTable("PROJETOS");

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__PROJETOS__AC728E50234C2C44")
                    .IsUnique();

                entity.Property(e => e.ProjetoId).HasColumnName("PROJETO_ID");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.IdTema).HasColumnName("ID_TEMA");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROJETOS__ID_TEM__5FB337D6");
            });

            modelBuilder.Entity<Temas>(entity =>
            {
                entity.HasKey(e => e.Temaid);

                entity.ToTable("TEMAS");

                entity.HasIndex(e => e.Tema)
                    .HasName("UQ__TEMAS__B7FF44CE302BA7BE")
                    .IsUnique();

                entity.Property(e => e.Temaid).HasColumnName("TEMAID");

                entity.Property(e => e.Ativo).HasColumnName("ATIVO");

                entity.Property(e => e.Tema)
                    .IsRequired()
                    .HasColumnName("TEMA")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.HasKey(e => e.TipoUsuarioId);

                entity.ToTable("TIPO_USUARIOS");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TIPO_USU__B6FCAAA29C483329")
                    .IsUnique();

                entity.Property(e => e.TipoUsuarioId).HasColumnName("TIPO_USUARIO_ID");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF7246C3D0752")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__4D94879B");
            });
        }
    }
}
