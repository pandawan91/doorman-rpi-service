namespace doorman_rpi_service.implementations.factories
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public static class HttpClientFactory
    {
        public static HttpClient Create(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
