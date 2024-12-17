namespace AppDbContext.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public bool? Enabled { get; set; }


        //Relacion con tabla Categorias - llave F
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
    }
}
