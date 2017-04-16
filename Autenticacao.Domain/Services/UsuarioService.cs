using System;
using Autenticacao.Domain.Entities;
using Autenticacao.Domain.Interfaces.Repositories;
using Autenticacao.Domain.Interfaces.Services;

namespace Autenticacao.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool VerificarEmail(string email)
        {
            return _usuarioRepository.Get(f => f.Email.Equals(email)) != null;
        }

        public bool VerificarEmailESenha(string email, string senha)
        {
            return _usuarioRepository.Get(f => f.Email.Equals(email) && f.Senha.Equals(senha)) != null;
        }
    }
}
