namespace TiendaRopa.Models
{
    public class ProductoApi
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public string? Categoria { get; set; }

        // La API no devuelve Disponible — se deriva del stock
        public bool Disponible => Stock > 0;
    }

    public class CategoriaApi
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }
    }
}
