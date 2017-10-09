namespace doorman_rpi_service
{
    using implementations.services;
    using interfaces.services;
    using System;
    using System.Text;
    using System.Threading;

    class Program
    {
        private static IArduinoCommunicationService _arduinoCommunicationService;
        private static IWebApiCommunicationService _webApiCommunicationService;
        private static bool _continue = false;

        static void Main(string[] args)
        {
            _arduinoCommunicationService = new ArduinoCommunicationService();
            _webApiCommunicationService = new WebApiCommunictaionService();

            var communicationThread = new Thread(CommunicationThread);
            _continue = true;
            communicationThread.Start();
            Console.WriteLine("doorman-rpi-service is ready and running");
            communicationThread.Join();

            _arduinoCommunicationService.CloseSerialPort();
        }

        private static void CommunicationThread()
        {
            while (_continue)
            {
                var cardId = _arduinoCommunicationService.ReadIncomingData();
                
                if(cardId >= 0)
                {
                    var validationRequest = _webApiCommunicationService.ValidateCardId(cardId);
                    validationRequest.Wait();
                    if (validationRequest.IsCompleted)
                        _arduinoCommunicationService.SendWebApiResponse(validationRequest.Result);
                }
            }
        }
    }
}
