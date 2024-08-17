using Microsoft.Data.SqlClient;

namespace CoreSaveMultiple.Models
{
    public class DbConnection
    {
        private readonly IConfiguration _configuration;
        public DbConnection(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public SqlConnection getConnection()
        {
            string myConn = Convert.ToString(_configuration.GetConnectionString("DefaultConnection"));
            SqlConnection con = new SqlConnection(myConn);
            return con;
        }
    }
}
