using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Infrastructure.Data.ADO
{
    public class Connection
    {
        private const string connectionString = @"Data Source=autenticacaosql.database.windows.net;Initial Catalog=AutenticacaoDB;Integrated Security=False;User ID=userAutenticacao;Password=User123qwe;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection connection = null;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            return connection;
        }

        private Connection()
        {

        }
    }
}
