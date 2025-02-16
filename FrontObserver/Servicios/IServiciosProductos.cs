namespace FrontObserver.Servicios
{
    public interface IServiciosProductos
    {
        Task<HttpResponseWrapper<T>> GetProductos<T>(string url);
        Task<HttpResponseWrapper<object>> PostProductos<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostProductos<T,TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> PutProductos<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutProductos<T, TActionResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> DeleteProductos(string url);
        Task<HttpResponseWrapper<TActionResponse>> DeleteProductos<TActionResponse>(string url);    
    }
}
