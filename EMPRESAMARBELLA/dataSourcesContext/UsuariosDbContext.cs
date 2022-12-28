using EMPRESAMARBELLA.dominio.modelos;
using Microsoft.EntityFrameworkCore;

namespace EMPRESAMARBELLA.dataSourcesContext.Entities
{
    public partial class UsuariosDbContext:DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

                entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("Nombre");

                entity.Property(e => e.Telefono)
                .HasColumnName("telefono");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
