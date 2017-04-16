using System;
using Autenticacao.Application.Interfaces;
using Autenticacao.Domain.Entities;
using Autenticacao.Domain.Interfaces.Services;
using Autenticacao.Infrastructure.Data.ADO;

namespace Autenticacao.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService) 
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void Criar(Usuario usuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.Save(usuario);

            if (usuario.Telefones.Count > 0)
            {
                TelefoneDAO telefoneDAO = new TelefoneDAO();

                foreach (Telefone telefone in usuario.Telefones)
                {
                    telefoneDAO.Save(telefone, usuario);
                }
            }
        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = _usuarioService.Get(f => f.Email.Equals(email) && f.Senha.Equals(senha));

            usuario.AtualizarDataUltimoLogin();

            _usuarioService.Update(usuario);

            return usuario;
        }
        
        public bool VerificarEmail(string email)
        {
            return _usuarioService.Get(f => f.Email.Equals(email)) != null;
        }

        public bool VerificarEmailESenha(string email, string senha)
        {
            return _usuarioService.Get(f => f.Email.Equals(email) && f.Senha.Equals(senha)) != null;
        }

        public string ValidarTokenDoUsuario(string token, string id)
        {
            Usuario usuario = _usuarioService.Get(f => f.Id.ToString().Equals(id));

             if (string.IsNullOrWhiteSpace(token) || !usuario.Token.Equals(token) && usuario.DataUltimoLogin.Minute < 30)
                return "Não autorizado.";
            else if (usuario.Token.Equals(token) && usuario.DataUltimoLogin.Minute > 30)
                return "Sessão inválida.";
            else
                return "";
        }
    }
}
