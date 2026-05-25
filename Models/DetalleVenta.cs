namespace TiendaRopa.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoApiId { get; set; }    // Id del producto que viene de la API del profesor
        public string ProductoNombre { get; set; } = "";  // Guardamos nombre para historial
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        // Navegación
        public Venta? Venta { get; set; }
    }
}
