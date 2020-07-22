using System.Collections.Generic;

namespace VentasApi.Models.Entity
{
    public partial class Cliente
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Nic { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
