using Autenticacao.API.Model;
using Autenticacao.Application.Interfaces;
using Autenticacao.Domain.Entities;
using Autenticacao.Infrastructure.Security;
using System;
using System.Net;
using System.Web.Http;

namespace Autenticacao.API.Controllers
{
    [RoutePrefix("api/signup")]
    public class SignUpController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApplication;

        public SignUpController(IUsuarioAppService usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        // POST: api/SignUp
        [HttpPost]
        public IHttpActionResult Registrar(Usuario usuario)
        {
            try
            {
                if (!_usuarioApplication.VerificarEmail(usuario.Email))
                {
                    Usuario novoUsuario = new Usuario(usuario.Nome, usuario.Email, Criptografia.Hash(usuario.Senha),
                        usuario.Telefones, Jwt.GenerateToken(usuario.Email));

                    _usuarioApplication.Criar(novoUsuario);

                    return Created("Usuario", novoUsuario);
                }
                else
                {
                    return CustomMessage.Create(HttpStatusCode.Conflict, "E-mail já cadastrado.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
