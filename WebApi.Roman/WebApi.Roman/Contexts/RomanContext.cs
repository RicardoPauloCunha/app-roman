using Microsoft.EntityFrameworkCore;

namespace WebApi.Roman.Domains
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {

        }

        public RomanContext(DbContextOptions<RomanContext> options) : base(options)
        {

        }

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Equipes> Equipes { get; set; }
        public virtual DbSet<Professores> Professores { get; set; }
        public virtual DbSet<Projetos> Projetos { get; set; }
        public virtual DbSet<Temas> Temas { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.ProfessoresEquipes'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connection string");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradores>(entity =>
            {
                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Administradores)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__Usuar__48CFD27E");
            });

            modelBuilder.Entity<Equipes>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .HasName("UQ__Equipes__008BA9EF25ACFA7E")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professores>(entity =>
            {
                entity.HasIndex(e => e.UsuariosId)
                    .HasName("UQ__Professo__48BE79C8F440EAC8")
                    .IsUnique();

                entity.HasOne(d => d.Equipe)
                    .WithMany(p => p.Professores)
                    .HasForeignKey(d => d.EquipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professor__Equip__4316F928");

                entity.HasOne(d => d.Usuarios)
                    .WithOne(p => p.Professores)
                    .HasForeignKey<Professores>(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professor__Usuar__4222D4EF");
            });

            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.HasIndex(e => e.Titutlo)
                    .HasName("UQ__Projetos__F7084C4D3A0C40BB")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.Titutlo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projetos__Profes__5070F446");

                entity.HasOne(d => d.Tema)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.TemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projetos__TemaId__4F7CD00D");
            });

            modelBuilder.Entity<Temas>(entity =>
            {
                entity.HasIndex(e => e.Tema)
                    .HasName("UQ__Temas__8F79CA086950568B")
                    .IsUnique();

                entity.Property(e => e.Tema)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.HasIndex(e => e.Descricao)
                    .HasName("UQ__TiposUsu__008BA9EF90EA3070")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053472ABC12A")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__TipoUs__3B75D760");
            });
        }
    }
}
