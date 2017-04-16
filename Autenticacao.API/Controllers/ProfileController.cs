using Autenticacao.API.Model;
using Autenticacao.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Autenticacao.API.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApplication;

        public ProfileController(IUsuarioAppService usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        // GET: api/Profile/5
        public IHttpActionResult Get(string id)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;

            if (headers.Contains("Authorization"))
            {
                token = headers.GetValues("Authorization").FirstOrDefault();
            }

            try
            {
                string retorno = _usuarioApplication.ValidarTokenDoUsuario(token, id);

                if (!string.IsNullOrWhiteSpace(retorno))
                    return CustomMessage.Create(HttpStatusCode.Unauthorized, retorno);
                else
                    return Ok(_usuarioApplication.Get(f => f.Id.ToString().Equals(id)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
