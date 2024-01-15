namespace tiendaApi.Conections
{
    public class CobectionBD
    {
        private string connectionString = string.Empty;

        /*Builder*/
        public CobectionBD()
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
