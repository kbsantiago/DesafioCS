using Autenticacao.Domain.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Autenticacao.Infrastructure.Data.ADO
{
    public class UsuarioDAO
    {
        public void Save(Usuario usuario)
        {
            SqlConnection sqlConnection = Connection.GetConnection();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("INSERT INTO dbo.Usuario (Id, Nome, Email, Senha, DataCriacao, DataAtualizacao, DataUltimoLogin, Token) ");
            commandText.Append("     VALUES (@Id, @Nome, @Email, @Senha, @DataCriacao, @DataAtualizacao, @DataUltimoLogin, @Token) ");

            using (SqlCommand command = new SqlCommand(commandText.ToString(), sqlConnection))
            {
                command.Parameters.Add("@Id", SqlDbType.VarChar, 250).Value = usuario.Id.ToString();
                command.Parameters.Add("@Nome", SqlDbType.VarChar, 250).Value = usuario.Nome;
                command.Parameters.Add("@Email", SqlDbType.VarChar, 250).Value = usuario.Email;
                command.Parameters.Add("@Senha", SqlDbType.VarChar, 250).Value = usuario.Senha;
                command.Parameters.Add("@DataCriacao", SqlDbType.DateTime).Value = usuario.DataCriacao;
                command.Parameters.Add("@DataAtualizacao", SqlDbType.DateTime).Value = usuario.DataAtualizacao;
                command.Parameters.Add("@DataUltimoLogin", SqlDbType.DateTime).Value = usuario.DataUltimoLogin;
                command.Parameters.Add("@Token", SqlDbType.VarChar, 250).Value = usuario.Token;

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
