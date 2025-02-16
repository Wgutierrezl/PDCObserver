
using System.Text;
using System.Text.Json;

namespace FrontObserver.Servicios
{
    public class ServiviciosProductos : IServiciosProductos
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ServiviciosProductos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<object>> DeleteProductos(string url)
        {
            var responsehttp=await _httpClient.DeleteAsync(url);
            var content=await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(null, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> DeleteProductos<TActionResponse>(string url)
        {
            var responsehttp = await _httpClient.DeleteAsync(url);
            var content = await responsehttp.Content.ReadAsStringAsync();
            if(responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<TActionResponse>(content,JsonSerializerOptions);
                return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
            }    
            return new HttpResponseWrapper<TActionResponse>(default,!responsehttp.IsSuccessStatusCode,responsehttp);
        }

        public async Task<HttpResponseWrapper<T>> GetProductos<T>(string url)
        {
            var responseHttp=await _httpClient.GetAsync(url);
            var content = await responseHttp.Content.ReadAsStringAsync();
            if (responseHttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<T>(content,JsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }
            return new HttpResponseWrapper<T>(default, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> PostProductos<T>(string url, T model)
        {
            var MessageJson = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PostAsync(url, MessageContent);
            return new HttpResponseWrapper<object>(null, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostProductos<T, TActionResponse>(string url, T model)
        {
            var MessageJson = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PostAsync(url, MessageContent);
            var Content=await responsehttp.Content.ReadAsStringAsync();
            if(responsehttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(Content, JsonSerializerOptions);
                return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);

        }

        public async Task<HttpResponseWrapper<object>> PutProductos<T>(string url, T model)
        {
            var MessageJson=JsonSerializer.Serialize(model);
            var MessageContent=new StringContent(MessageJson,Encoding.UTF8, "application/json");
            var responsehttp=await _httpClient.PutAsync(url, MessageContent);
            return new HttpResponseWrapper<object>(null,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PutProductos<T, TActionResponse>(string url, T model)
        {
            var MessageJson = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PutAsync(url, MessageContent);
            var Content=await responsehttp.Content.ReadAsStringAsync();
            if(responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<TActionResponse>(Content,JsonSerializerOptions);
                return new HttpResponseWrapper<TActionResponse>(response,false,responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }
    }
}
