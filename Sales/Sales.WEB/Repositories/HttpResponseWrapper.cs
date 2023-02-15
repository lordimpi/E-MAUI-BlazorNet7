using System.Net;

namespace Sales.WEB.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;
            return statusCode switch
            {
                HttpStatusCode.NotFound => "Recurso no encontrado",
                HttpStatusCode.BadRequest => await HttpResponseMessage.Content.ReadAsStringAsync(),
                HttpStatusCode.Unauthorized => "Tienes que logearte para hacer esta operación",
                HttpStatusCode.Forbidden => "No tienes permisos para hacer esta operación",
                _ => "Ha ocurrido un error inesperado",
            };
        }
    }
}
