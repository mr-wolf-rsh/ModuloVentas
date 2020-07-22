using System;

namespace VentasApi.Models.SP
{
    public class Facturas_Por_Importe
    {
        public string CNombres { get; set; }
        public string CApellidos { get; set; }
        public string Nic { get; set; }
        public string Categoria { get; set; }
        public string VNombres { get; set; }
        public string VApellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal? Total { get; set; }
    }
}
