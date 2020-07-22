using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VentasApi.Models.SP;

namespace VentasApi.Models.DB
{
    public partial class SPContext : DbContext
    {
        private DbSet<Clientes_Categoria_A_Sin_Factura> Clientes_Categoria_A_Sin_Factura { get; set; }
        private DbSet<Facturas_Por_Importe> Facturas_Por_Importe { get; set; }
        private DbSet<Productos> Productos { get; set; }
        private DbSet<Vendedores_Ingreso_2019> Vendedores_Ingreso_2019 { get; set; }

        public SPContext()
        {
        }

        public SPContext(DbContextOptions<SPContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No key            
            modelBuilder.Entity<Clientes_Categoria_A_Sin_Factura>().HasNoKey();
            modelBuilder.Entity<Facturas_Por_Importe>().HasNoKey();
            modelBuilder.Entity<Productos>().HasNoKey();
            modelBuilder.Entity<Vendedores_Ingreso_2019>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        public async Task<List<Clientes_Categoria_A_Sin_Factura>> Listar_Clientes_Categoria_A_Sin_FacturaAsync()
        {
            try
            {
                // Processing 
                string sqlQuery = $@"EXEC [dbo].[usp_Listar_Clientes_Categoria_A_Sin_Factura] ";

                //Output Data
                return await Clientes_Categoria_A_Sin_Factura.FromSqlRaw(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Facturas_Por_Importe>> Listar_Facturas_Por_ImporteAsync()
        {
            try
            {
                // Processing 
                string sqlQuery = $@"EXEC [dbo].[usp_Listar_Facturas_Por_Importe] ";

                //Output Data
                return await Facturas_Por_Importe.FromSqlRaw(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Productos>> Listar_ProductosAsync()
        {
            try
            {
                // Processing 
                string sqlQuery = $@"EXEC [dbo].[usp_Listar_Productos] ";

                //Output Data
                return await Productos.FromSqlRaw(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vendedores_Ingreso_2019>> Listar_Vendedores_Ingreso_2019Async()
        {
            try
            {
                // Processing 
                string sqlQuery = $@"EXEC [dbo].[usp_Listar_Vendedores_Ingreso_2019] ";

                //Output Data
                return await Vendedores_Ingreso_2019.FromSqlRaw(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_DetalleFactura_Un_Producto_MinimoAsync(int? FacturaId, int? ProductoId, int? Cantidad, decimal? PrecioUnitario)
        {
            try
            {
                // Parameters
                SqlParameter p_FacturaId = new SqlParameter("@FacturaId", FacturaId ?? (object)DBNull.Value)
                {
                    Direction = ParameterDirection.Input,
                    DbType = DbType.Int32,
                    Size = 4
                };

                SqlParameter p_ProductoId = new SqlParameter("@ProductoId", ProductoId ?? (object)DBNull.Value)
                {
                    Direction = ParameterDirection.Input,
                    DbType = DbType.Int32,
                    Size = 4
                };

                SqlParameter p_Cantidad = new SqlParameter("@Cantidad", Cantidad ?? (object)DBNull.Value)
                {
                    Direction = ParameterDirection.Input,
                    DbType = DbType.Int32,
                    Size = 4
                };

                SqlParameter p_PrecioUnitario = new SqlParameter("@PrecioUnitario", PrecioUnitario ?? (object)DBNull.Value)
                {
                    Direction = ParameterDirection.Input,
                    DbType = DbType.Decimal,
                    Size = 9
                };

                // Processing 
                string sqlQuery = $@"EXEC [dbo].[usp_Registrar_DetalleFactura_Un_Producto_Minimo] @FacturaId, @ProductoId, @Cantidad, @PrecioUnitario";

                //Execution
                Database.ExecuteSqlRaw(sqlQuery, p_FacturaId, p_ProductoId, p_Cantidad, p_PrecioUnitario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}