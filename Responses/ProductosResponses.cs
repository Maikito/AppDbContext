namespace AppDbContext.Responses
{
    public class ProductosResponses
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        //de la categoria
        public int CategoriaID { get; set; }
    }
}
