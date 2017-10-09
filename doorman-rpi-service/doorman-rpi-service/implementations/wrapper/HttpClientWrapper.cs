namespace doorman_rpi_service.implementations.wrapper
{
    using interfaces.wrapper;
    using System;
    using System.Net.Http;

    public class HttpClientWrapper : IHttpClientWrapper, IDisposable
    {
        private readonly HttpClient _client;

        public HttpClientWrapper(HttpClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            _client = client;
        }

        public HttpResponseMessage Get(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            return _client.GetAsync(path).Result;
        }

        public static HttpClientWrapper Create()
        {
            return new HttpClientWrapper(factories.HttpClientFactory.Create("http://doorman-db-api.azurewebsites.net"));
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
