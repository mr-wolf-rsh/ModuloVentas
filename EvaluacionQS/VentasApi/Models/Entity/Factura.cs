using System;
using System.Collections.Generic;

namespace VentasApi.Models.Entity
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int FacturaId { get; set; }
        public string Serie { get; set; }
        public string Codigo { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
