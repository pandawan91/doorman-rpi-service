namespace doorman_rpi_service.interfaces.services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IArduinoCommunicationService
    {
        long ReadIncomingData();
        void SendWebApiResponse(bool isValid);
        void CloseSerialPort();
    }
}
