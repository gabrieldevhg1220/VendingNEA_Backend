using Microsoft.EntityFrameworkCore;
using VendingNEA_Backend.Models;

namespace VendingNEA_Backend.Data
{
    public class VendingNEADbContext : DbContext
    {
        public VendingNEADbContext() { }
        public VendingNEADbContext(DbContextOptions<VendingNEADbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Repositor> Repositores { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Establecimiento> Establecimientos { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Acuerdo> Acuerdos { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<StockMaquina> StockMaquinas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasKey(e => e.Legajo);

            // REPOSITOR - Shared Primary Key (usa legajo como PK y FK)
            modelBuilder.Entity<Repositor>()
                .HasKey(r => r.Legajo);

            modelBuilder.Entity<Repositor>()
                .HasOne(r => r.Empleado)
                .WithMany()
                .HasForeignKey(r => r.Legajo)
                .OnDelete(DeleteBehavior.Cascade);

            // TÉCNICO - Shared Primary Key (usa legajo como PK y FK)
            modelBuilder.Entity<Tecnico>()
                .HasKey(t => t.Legajo);

            modelBuilder.Entity<Tecnico>()
                .HasOne(t => t.Empleado)
                .WithMany()
                .HasForeignKey(t => t.Legajo)
                .OnDelete(DeleteBehavior.Cascade);

            // Resto de relaciones (sin cambios)
            modelBuilder.Entity<Establecimiento>().HasKey(es => es.IdEstablecimiento);
            modelBuilder.Entity<Responsable>().HasKey(res => res.IdResponsable);
            modelBuilder.Entity<Responsable>().HasOne<Establecimiento>().WithMany().HasForeignKey(res => res.IdEstablecimiento);
            modelBuilder.Entity<Acuerdo>().HasKey(a => a.IdAcuerdo);
            modelBuilder.Entity<Acuerdo>().HasOne<Establecimiento>().WithMany().HasForeignKey(a => a.IdEstablecimiento);
            modelBuilder.Entity<Liquidacion>().HasKey(l => l.IdLiquidacion);
            modelBuilder.Entity<Liquidacion>().HasOne<Acuerdo>().WithMany().HasForeignKey(l => l.IdAcuerdo);
            modelBuilder.Entity<Pago>().HasKey(p => p.IdPago);
            modelBuilder.Entity<Pago>().HasOne<Liquidacion>().WithMany().HasForeignKey(p => p.IdLiquidacion);
            modelBuilder.Entity<Maquina>().HasKey(m => m.IdMaquina);
            modelBuilder.Entity<Maquina>().HasOne<Acuerdo>().WithMany().HasForeignKey(m => m.IdAcuerdo);
            modelBuilder.Entity<Producto>().HasKey(pr => pr.IdProducto);
            modelBuilder.Entity<Proveedor>().HasKey(pro => pro.IdProveedor);
            modelBuilder.Entity<Compra>().HasKey(c => c.IdCompra);
            modelBuilder.Entity<Compra>().HasOne<Proveedor>().WithMany().HasForeignKey(c => c.IdProveedor);
            modelBuilder.Entity<DetalleCompra>().HasKey(d => d.IdDetalle);
            modelBuilder.Entity<DetalleCompra>().HasOne<Compra>().WithMany().HasForeignKey(d => d.IdCompra);
            modelBuilder.Entity<DetalleCompra>().HasOne<Producto>().WithMany().HasForeignKey(d => d.IdProducto);
            modelBuilder.Entity<StockMaquina>().HasKey(s => s.IdStock);
            modelBuilder.Entity<StockMaquina>().HasOne<Maquina>().WithMany().HasForeignKey(s => s.IdMaquina);
            modelBuilder.Entity<StockMaquina>().HasOne<Producto>().WithMany().HasForeignKey(s => s.IdProducto);
            modelBuilder.Entity<Vehiculo>().HasKey(v => v.IdVehiculo);
            modelBuilder.Entity<Ruta>().HasKey(r => r.IdRuta);
            modelBuilder.Entity<Ruta>().HasOne<Vehiculo>().WithMany().HasForeignKey(r => r.IdVehiculo);
            modelBuilder.Entity<Ruta>().HasOne<Repositor>().WithMany().HasForeignKey(r => r.LegajoRepositor);
            modelBuilder.Entity<Visita>().HasKey(vi => vi.IdVisita);
            modelBuilder.Entity<Visita>().HasOne<Ruta>().WithMany().HasForeignKey(vi => vi.IdRuta);
            modelBuilder.Entity<Visita>().HasOne<Maquina>().WithMany().HasForeignKey(vi => vi.IdMaquina);
            modelBuilder.Entity<Visita>().HasOne<Repositor>().WithMany().HasForeignKey(vi => vi.LegajoRepositor);
            modelBuilder.Entity<Venta>().HasKey(ve => ve.IdVenta);
            modelBuilder.Entity<Venta>().HasOne<Visita>().WithMany().HasForeignKey(ve => ve.IdVisita);
            modelBuilder.Entity<Venta>().HasOne<Maquina>().WithMany().HasForeignKey(ve => ve.IdMaquina);
            modelBuilder.Entity<Venta>().HasOne<Producto>().WithMany().HasForeignKey(ve => ve.IdProducto);
            modelBuilder.Entity<Mantenimiento>().HasKey(ma => ma.IdMantenimiento);
            modelBuilder.Entity<Mantenimiento>().HasOne<Maquina>().WithMany().HasForeignKey(ma => ma.IdMaquina);
            modelBuilder.Entity<Mantenimiento>().HasOne<Tecnico>().WithMany().HasForeignKey(ma => ma.LegajoTecnico);
            modelBuilder.Entity<Incidente>().HasKey(i => i.IdIncidente);
            modelBuilder.Entity<Incidente>().HasOne<Maquina>().WithMany().HasForeignKey(i => i.IdMaquina);
            modelBuilder.Entity<Incidente>().HasOne<Empleado>().WithMany().HasForeignKey(i => i.LegajoEmpleado);

            // Precisiones decimales
            modelBuilder.Entity<Acuerdo>().Property(a => a.ValorCondicion).HasPrecision(10, 2);
            modelBuilder.Entity<Compra>().Property(c => c.MontoTotal).HasPrecision(12, 2);
            modelBuilder.Entity<DetalleCompra>().Property(d => d.PrecioUnitario).HasPrecision(10, 2);
            modelBuilder.Entity<Liquidacion>().Property(l => l.MontoTotal).HasPrecision(12, 2);
            modelBuilder.Entity<Mantenimiento>().Property(m => m.Costo).HasPrecision(12, 2);
            modelBuilder.Entity<Pago>().Property(p => p.Monto).HasPrecision(12, 2);
            modelBuilder.Entity<Producto>().Property(pr => pr.Precio).HasPrecision(10, 2);
            modelBuilder.Entity<Venta>().Property(v => v.Total).HasPrecision(10, 2);
            modelBuilder.Entity<Venta>().Property(v => v.MontoRecibido).HasPrecision(10, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}