namespace tiendaApi.Conections
{
    public class ConectionBD
    {
        private string connectionString = string.Empty;

        /*Builder*/
        public ConectionBD()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile
                ("appsettings.json").Build();
            /*Values asignation*/
            connectionString = builder.GetSection
                ("ConnectionStrings:conexionmaestra").Value;

        }

        /*Return String*/
        public string cadenaSQL()
        {
            return connectionString;
        }

    }
}
