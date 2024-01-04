using Backend.Objects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Backend.Controllers
{
 
    [ApiController]
    [Route("apicrud")]
    public class ApiCRUD : ControllerBase
    {
        List<Users> usuarios = new List<Users>
        {
            new Users{
                Id = 1,
                Name = "Carlos"
            },
            new Users
            {
                Id = 2,
                Name = "Raúl"
            }
        }; 

        /*
         ApiGet
         */
        [HttpGet]
        [Route("getDatos")]
        public dynamic getDatos()
        {
            return this.usuarios;
        }
        /*
         ApiPost
         */
        [HttpPost]
        [Route("setDatos")]
        public dynamic postDatos(dynamic datos)
        {
            Console.WriteLine(datos);
            try
            {
                string jsonData = JsonConvert.SerializeObject(datos); // Convertir a JSON
                Users usuario = JsonConvert.DeserializeObject<Users>(jsonData); // Deserializar JSON a objeto Users
                Console.WriteLine(usuario.Name,"nombre");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }




            return datos;
        }
        /*
         ApiUpdate
         */
        //[HttpPut]
        //[Route("putDatos")]
        //public dynamic putDatos(dynamic datos)
        //{
            
        //        int Id = datos.Id;
        //        string Name = datos.Name;

        //        usuarios[Id].Name = Name;
            
               
            

        //    return "Usuario editado";

        //}
        ///*
        // ApiDelete
        // */
        //[Route("deleteDatos")]
        //[HttpDelete]
        //public dynamic deleteDatos(dynamic datos)
        //{
        //    int Id = datos.Id;
        //    usuarios.RemoveAt(Id);
        //    return "Usuario removido"; 
        //}

    }
}
