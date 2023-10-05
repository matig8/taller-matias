using System.Data.SqlClient;

namespace WEB_TALLER.Datos
{
    public class Conexion
    {
        private string CadenaSQL = string.Empty;

        public Conexion() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        public string GetCadenaSQL()
        {
            return CadenaSQL;
        }
    }
}
