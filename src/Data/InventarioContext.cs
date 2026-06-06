using Microsoft.EntityFrameworkCore;
using InventarioMateriales.Models;

namespace InventarioMateriales.Data
{
    /// <summary>
    /// Contexto de Entity Framework Core para la base de datos de inventario
    /// </summary>
    public class InventarioContext : DbContext
    {
        public DbSet<Material> Materiales { get; set; }

        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Materiales
            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Materiales");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Numero_tipo)
                    .HasMaxLength(50);

                entity.Property(e => e.Numero_pedido)
                    .HasMaxLength(50);

                entity.Property(e => e.PVP)
                    .HasPrecision(10, 2);

                entity.Property(e => e.Descuento)
                    .HasPrecision(5, 2);

                entity.Property(e => e.Neto)
                    .HasPrecision(10, 2);

                entity.Property(e => e.Neto_UE)
                    .HasPrecision(10, 2);

                entity.Property(e => e.Fecha_precio)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Fecha_creacion)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Fecha_actualizacion)
                    .HasDefaultValueSql("GETDATE()");

                // Crear índices
                entity.HasIndex(e => e.Categoria).HasName("IX_Categoria");
                entity.HasIndex(e => e.Numero_pedido).HasName("IX_Numero_pedido");
                entity.HasIndex(e => e.Descripcion).HasName("IX_Descripcion");
            });
        }
    }
}
