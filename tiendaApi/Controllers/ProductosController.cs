using Microsoft.AspNetCore.Mvc;
using tiendaApi.Data;
using tiendaApi.Model;

namespace tiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController
    {
        [HttpGet]
        public async Task<ActionResult<List<ModelProductos>>> getProductos()
        {
            var funcion = new DataProductos();

            var lista = await funcion.Mostrarproductos();

            return lista;
        }
    }
}
