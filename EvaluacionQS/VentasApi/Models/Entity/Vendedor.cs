using System;
using System.Collections.Generic;

namespace VentasApi.Models.Entity
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Factura = new HashSet<Factura>();
        }

        public int VendedorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
