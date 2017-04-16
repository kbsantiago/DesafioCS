using Autenticacao.API.Model;
using Autenticacao.Application;
using Autenticacao.Application.Interfaces;
using Autenticacao.Domain.Entities;
using Autenticacao.Infrastructure.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Autenticacao.API.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApplication;

        public LoginController(IUsuarioAppService usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        // POST: api/login
        [HttpPost]
        public IHttpActionResult Autenticar(Login login)
        {
            try
            {
                if (_usuarioApplication.VerificarEmail(login.Email))
                    if (_usuarioApplication.VerificarEmailESenha(login.Email, Criptografia.Hash(login.Senha)))
                        return Ok(_usuarioApplication.Autenticar(login.Email, Criptografia.Hash(login.Senha)));
                    else
                        return CustomMessage.Create(HttpStatusCode.Unauthorized, "Usuário e/ou senha inválidos.");
                else
                    return CustomMessage.Create(HttpStatusCode.Unauthorized, "E-mail informado é inválido.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
