namespace doorman_rpi_service.interfaces.wrapper
{
    using System.Net.Http;

    public interface IHttpClientWrapper
    {
        HttpResponseMessage Get(string path);
    }
}
