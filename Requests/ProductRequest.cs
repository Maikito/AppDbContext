namespace AppDbContext.Requests
{
    public class ProductRequest
    {
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }


        //Relacion con Categoria
        public int CategoriaID { get; set; }
    }
}
