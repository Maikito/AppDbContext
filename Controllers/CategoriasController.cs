using AppDbContext.Models;
using AppDbContext.Requests;
using AppDbContext.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDbContext.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpPost]
        public void Insert(CategoriaRequest categoriaRequest)
        {
            using (var context = new AplicacionContext())
            {
                Categoria categoria = new Categoria
                {
                    NombreCateg = categoriaRequest.NombreCateg,
                    Descripcion = categoriaRequest.Descripcion
                };
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }


        [HttpGet]
        public List<CategoriasResponses> ListarCategorias()
        {
            using (var context = new AplicacionContext())
            {
                var categorias = context.Categorias.ToList();

                var response = categorias.Select(x => new CategoriasResponses
                {
                    CategoriaID = x.CategoriaID,
                    NombreCateg = x.NombreCateg,
                    Descripcion = x.Descripcion
                }).ToList();

                return response;
            }
        }

        //por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaPorID(int id)
        {

            using (var context = new AplicacionContext())
            {
                var categoria = await context.Categorias.FindAsync(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                return categoria;

            }

        }
    }
}
