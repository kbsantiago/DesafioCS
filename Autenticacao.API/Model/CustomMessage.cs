using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Autenticacao.API.Model
{
    public class CustomMessage : IHttpActionResult
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }

        public static CustomMessage Create(HttpStatusCode statusCode, string message)
        {
            return new CustomMessage(statusCode, message);
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var resp = new CustomMessage(StatusCode, Message);
            var response = new HttpResponseMessage(StatusCode);
            response.Content = new StringContent(JsonConvert.SerializeObject(resp), System.Text.Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }

        private CustomMessage(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}