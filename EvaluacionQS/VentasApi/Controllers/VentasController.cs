using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VentasApi.Models.DB;
using VentasApi.Models.Entity;
using VentasApi.Models.SP;

namespace VentasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly SPContext _spContext;

        public VentasController(SPContext spContext)
        {
            _spContext = spContext;
        }

        // GET: api/Ventas/ClientesCategoriaASinFactura
        [HttpGet("ClientesCategoriaASinFactura")]
        public async Task<ActionResult<List<Clientes_Categoria_A_Sin_Factura>>> GetClientesCategoriaASinFactura()
        {
            return await _spContext.Listar_Clientes_Categoria_A_Sin_FacturaAsync();
        }

        // GET: api/Ventas/FacturasPorImporte
        [HttpGet("FacturasPorImporte")]
        public async Task<ActionResult<List<Facturas_Por_Importe>>> GetFacturasPorImporte()
        {
            return await _spContext.Listar_Facturas_Por_ImporteAsync();
        }

        // GET: api/Ventas/Productos
        [HttpGet("Productos")]
        public async Task<ActionResult<List<Productos>>> GetProductos()
        {
            return await _spContext.Listar_ProductosAsync();
        }

        // GET: api/Ventas/FacturasPorImporte
        [HttpGet("VendedoresIngreso2019")]
        public async Task<ActionResult<List<Vendedores_Ingreso_2019>>> GetVendedoresIngreso2019()
        {
            return await _spContext.Listar_Vendedores_Ingreso_2019Async();
        }

        // POST: api/Ventas/RegistrarDetalleFacturaUnProductoMinimo
        [HttpPost("DetalleFacturaUnProductoMinimo")]
        public async Task RegistrarDetalleFacturaUnProductoMinimo([FromBody] DetalleFactura detalleFactura)
        {
            _spContext.Registrar_DetalleFactura_Un_Producto_MinimoAsync(
                detalleFactura.FacturaId, detalleFactura.ProductoId, detalleFactura.Cantidad, detalleFactura.PrecioUnitario);

            await _spContext.SaveChangesAsync();
        }
    }
}
