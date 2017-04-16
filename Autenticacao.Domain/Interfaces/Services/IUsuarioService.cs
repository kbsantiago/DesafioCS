using Autenticacao.Domain.Entities;

namespace Autenticacao.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        bool VerificarEmail(string email);

        bool VerificarEmailESenha(string email, string senha);
    }
}
