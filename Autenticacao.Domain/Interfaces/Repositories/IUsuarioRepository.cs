using Autenticacao.Domain.Entities;

namespace Autenticacao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        bool VerificarEmail(string email);

        bool VerificarEmailESenha(string email, string senha);
    }
}
