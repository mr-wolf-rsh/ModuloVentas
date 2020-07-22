using Microsoft.EntityFrameworkCore;
using VentasApi.Models.Entity;

namespace VentasApi.Models.DB
{
    public partial class db_ventasContext : DbContext
    {
        public db_ventasContext()
        {
        }

        public db_ventasContext(DbContextOptions<db_ventasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=db_ventas;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nic)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 5)");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Factura");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Producto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cliente");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.VendedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Vendedor");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
