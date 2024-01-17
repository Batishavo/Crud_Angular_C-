using System.Data;
using System.Data.SqlClient;

using tiendaApi.Conections;
using tiendaApi.Model;

namespace tiendaApi.Data
{
    public class DataProductos
    {
        ConectionBD cn = new ConectionBD();
        public async Task<List<ModelProductos>> Mostrarproductos()
        {
            
            var lista = new List<ModelProductos>();

            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos",sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var modelProctos = new ModelProductos();

                            modelProctos.id = (int)item["ID"];
                            modelProctos.description= (string)item["Descripcion"];
                            modelProctos.price = (decimal)item["Precio"];

                            lista.Add(modelProctos);
                        }
                    }

                }
            }
            
               return lista;
        }

        public async Task InsertarProductos(ModelProductos parametros)
        {
            using ( var sql = new SqlConnection (cn.cadenaSQL()))
            {
                using ( var cmd = new SqlCommand("insertarProductos",sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue
                        ("@descipcion",parametros.description);
                    cmd.Parameters.AddWithValue
                        ("@precio",parametros.price);
                
                    await sql.OpenAsync() ;
                    await cmd.ExecuteNonQueryAsync() ;
                }
            }
        }

        public async Task EsditarProductos(ModelProductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue
                        ("@id", parametros.id);
                    cmd.Parameters.AddWithValue
                        ("@precio", parametros.price);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarProductos(ModelProductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue
                        ("@id", parametros.id);
                    

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
