using AppDbContext.Models;
using AppDbContext.Requests;
using AppDbContext.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDbContext.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpPost]
        public void Insert(ProductRequest productRequest)
        {
            using (var context = new AplicacionContext())
            {
                Producto producto = new Producto
                {
                    NombreProducto = productRequest.NombreProducto,
                    Precio = productRequest.Precio,
                    Enabled = true,
                    CategoriaID = productRequest.CategoriaID
                };
                context.Productos.Add(producto);
                context.SaveChanges();
            }
        }


        
        [HttpGet]
        public List<ProductosResponses> ListarTodoProductos()
        {
            using (var context = new AplicacionContext())
            {
                var productos = context.Productos.ToList();

                var response = productos.Select(x => new ProductosResponses
                {
                    ProductoID = x.ProductoID,
                    NombreProducto = x.NombreProducto,
                    Precio = x.Precio,
                    CategoriaID = x.CategoriaID
                }).ToList();

                return response;
            }
        }


        //por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductPorID(int id)
        {

            using (var context = new AplicacionContext())
            {
                var producto = await context.Productos.FindAsync(id);

                if (producto == null)
                {
                    return NotFound();
                }

                return producto;
            }

        }




        
        [HttpGet]
        public List<ProductosResponses> ListarProductoJoinCategoria()
        {
            using (var context = new AplicacionContext())
            {
                var productos = context.Productos.ToList();

                var response = productos.Select(x => new ProductosResponses
                {
                    ProductoID = x.ProductoID,
                    NombreProducto = x.NombreProducto,
                    Precio = x.Precio,
                    CategoriaID = x.CategoriaID
                }).ToList();

                return response;
            }
        }
    }
}
