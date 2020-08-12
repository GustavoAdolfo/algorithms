using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aplicacao.HttpHelpers
{
    public class InternalServerMisterioErrorActionResult : IHttpActionResult
    {
        public InternalServerMisterioErrorActionResult(string message, HttpRequestMessage request)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Request = request ?? throw new ArgumentNullException(nameof(request));
        }

        public string Message { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(Message), 
                RequestMessage = Request
            };
            return response;
        }
    }
}