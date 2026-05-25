namespace TiendaRopa.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Navegación
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
