namespace VentasApi.Models.Entity
{
    public partial class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
