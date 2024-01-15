using Microsoft.AspNetCore.Mvc;
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

        }
    }
}
