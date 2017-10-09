namespace doorman_rpi_service.implementations.services
{
    using interfaces.services;
    using interfaces.wrapper;
    using System;
    using wrapper;
    using System.Threading.Tasks;
    using System.Net.Http;

    public class WebApiCommunictaionService : IWebApiCommunicationService
    {
        private readonly IHttpClientWrapper _clientWrapper;

        public WebApiCommunictaionService(IHttpClientWrapper clientWrapper)
        {
            if (clientWrapper == null)
                throw new ArgumentNullException("clientWrapper");
            _clientWrapper = clientWrapper;
        }

        public WebApiCommunictaionService() : this(HttpClientWrapper.Create()) { }

        public async Task<bool> ValidateCardId(long cardId)
        {
            if (cardId < 0)
                throw new ArgumentOutOfRangeException("cardId");
            var validate = false;
            var response = _clientWrapper.Get(String.Format("api/card/validate/{0}", cardId));
            if (response.IsSuccessStatusCode)
                validate = await response.Content.ReadAsAsync<bool>();
            return validate;
        }
    }
}
