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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DATA source=.\\SQLSERVERJIROS; initial catalog=Roman; user id=sa; pwd=ji_15?27101001_roS");
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
                    .HasConstraintName("FK__ADMINISTR__ID_US__48CFD27E");
            });

            modelBuilder.Entity<Equipes>(entity =>
            {
                entity.HasKey(e => e.EquipeId);

                entity.ToTable("EQUIPES");

                entity.HasIndex(e => e.Equipe)
                    .HasName("UQ__EQUIPES__F9437C8A780EE43E")
                    .IsUnique();

                entity.Property(e => e.EquipeId).HasColumnName("EQUIPE_ID");

                entity.Property(e => e.Equipe)
                    .IsRequired()
                    .HasColumnName("EQUIPE")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professores>(entity =>
            {
                entity.HasKey(e => e.ProfessorId);

                entity.ToTable("PROFESSORES");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("UQ__PROFESSO__91136B912DBED5D9")
                    .IsUnique();

                entity.Property(e => e.ProfessorId).HasColumnName("PROFESSOR_ID");

                entity.Property(e => e.IdArea).HasColumnName("ID_AREA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Professores)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROFESSOR__ID_AR__4316F928");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Professores)
                    .HasForeignKey<Professores>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROFESSOR__ID_US__4222D4EF");
            });

            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.HasKey(e => e.ProjetoId);

                entity.ToTable("PROJETOS");

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__PROJETOS__AC728E5059656F3B")
                    .IsUnique();

                entity.Property(e => e.ProjetoId).HasColumnName("PROJETO_ID");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.IdProfessor).HasColumnName("ID_PROFESSOR");

                entity.Property(e => e.IdTema).HasColumnName("ID_TEMA");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROJETOS__ID_PRO__5070F446");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROJETOS__ID_TEM__4F7CD00D");
            });

            modelBuilder.Entity<Temas>(entity =>
            {
                entity.HasKey(e => e.Temaid);

                entity.ToTable("TEMAS");

                entity.HasIndex(e => e.Tema)
                    .HasName("UQ__TEMAS__B7FF44CE7A0872CE")
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
                    .HasName("UQ__TIPO_USU__B6FCAAA29CB2469F")
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
                    .HasName("UQ__USUARIOS__161CF72403E4D43F")
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
                    .HasConstraintName("FK__USUARIOS__ID_TIP__3B75D760");
            });
        }
    }
}
