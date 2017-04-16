using System;
using Autenticacao.Domain.Entities;
using Autenticacao.Domain.Interfaces.Repositories;
using Autenticacao.Domain.Interfaces.Services;
using Autenticacao.Infrastructure.Data.Repositories;

namespace Autenticacao.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IRepositoryBase<Usuario> _context;

        public UsuarioService(RepositoryBase<Usuario> context)
            : base(context)
        {
            _context = context;
        }

        public bool VerificarEmail(string email)
        {
            return _context.Get(f => f.Email.Equals(email)) != null;
        }

        public bool VerificarEmailESenha(string email, string senha)
        {
            return _context.Get(f => f.Email.Equals(email) && f.Senha.Equals(senha)) != null;
        }
    }
}
