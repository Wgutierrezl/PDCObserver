using System.Net;
using System.Text;

namespace FrontObserver.Servicios
{
    public class HttpResponseWrapper<T>
    {
        public T? Response {  get; set; }
        public bool Error {  get; set; }
        public HttpResponseMessage? Httpresponsemessage { get; set; }

        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage? httpresponsemessage)
        {
            Response = response;
            Error = error;
            Httpresponsemessage = httpresponsemessage;
        }

        public async Task<string?> ErrorMessage()
        {
            if(!Error)
            {
                return null;
            }


            var codigoestatus = Httpresponsemessage!.StatusCode;
            if( codigoestatus == HttpStatusCode.NotFound)
            {
                return "Elemento no encontrado";
            }
            else if(codigoestatus == HttpStatusCode.Unauthorized)
            {
                return "No estas autorizado para hacer la operacion";
            }
            else if(codigoestatus == HttpStatusCode.Forbidden)
            {
               return "No tienes permisos para hacer esta operacion";
            }
            else if( codigoestatus == HttpStatusCode.BadRequest)
            {
                return await Httpresponsemessage.Content.ReadAsStringAsync();
            }

            return "Ha ocurrido un error";
        }
    }
}
