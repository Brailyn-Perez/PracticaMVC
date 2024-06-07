namespace CrudPracticaMVC.Datos
{
    public class ConexionDB
    {
        private string CadenaSQL = string.Empty;
        public ConexionDB()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getcadenaSQL()
        {
            return CadenaSQL;
        }
    }
}
