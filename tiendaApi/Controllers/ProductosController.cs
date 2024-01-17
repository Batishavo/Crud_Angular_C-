using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using tiendaApi.Data;
using tiendaApi.Model;

namespace tiendaApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController:ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ModelProductos>>> getProductos()
        {
            var funcion = new DataProductos();

            var lista = await funcion.Mostrarproductos();

            return lista;
        }

        [HttpPost]
        public async Task setDatos([FromBody] ModelProductos parametros)
        {
            var funcion = new DataProductos();
            
            await funcion.InsertarProductos(parametros);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] ModelProductos parametros)
        {
            var funcion = new DataProductos();
            parametros.id = id;
            await funcion.EsditarProductos(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new DataProductos();
            var parametros = new ModelProductos();
            parametros.id = id;

            await funcion.EliminarProductos(parametros);
            return NoContent();
        }


    }
}
