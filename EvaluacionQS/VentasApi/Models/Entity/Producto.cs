using System.Collections.Generic;

namespace VentasApi.Models.Entity
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
