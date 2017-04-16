using Autenticacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Infrastructure.Data.ADO
{
    public class TelefoneDAO
    {
        public void Save(Telefone telefone, Usuario usuario)
        {
            SqlConnection sqlConnection = Connection.GetConnection();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("INSERT INTO dbo.Telefone (Id, Ddd, Numero, Usuario_Id) ");
            commandText.Append("     VALUES (@Id, @Ddd, @Numero, @Usuario_Id) ");

            using (SqlCommand command = new SqlCommand(commandText.ToString(), sqlConnection))
            {
                command.Parameters.Add("@Id", SqlDbType.VarChar, 250).Value = telefone.Id.ToString();
                command.Parameters.Add("@Ddd", SqlDbType.VarChar, 250).Value = telefone.Ddd;
                command.Parameters.Add("@Numero", SqlDbType.VarChar, 250).Value = telefone.Numero;
                command.Parameters.Add("@Usuario_Id", SqlDbType.VarChar, 250).Value = usuario.Id.ToString();

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
