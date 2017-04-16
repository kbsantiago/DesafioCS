using Autenticacao.Domain.Entities;

namespace Autenticacao.Application.Interfaces
{
   public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        void Criar(Usuario usuario);

        Usuario Autenticar(string email, string senha);

        bool VerificarEmail(string email);

        bool VerificarEmailESenha(string email, string senha);

        string ValidarTokenDoUsuario(string token, string id);
    }
}
