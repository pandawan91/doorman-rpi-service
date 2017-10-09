namespace doorman_rpi_service.implementations.services
{
    using interfaces.services;
    using interfaces.wrapper;
    using System;
    using System.Text;
    using wrapper;

    public class ArduinoCommunicationService : IArduinoCommunicationService
    {
        private readonly ISerialPortWrapper _serialPortWrapper;

        public ArduinoCommunicationService(ISerialPortWrapper serialPortWrapper)
        {
            if (serialPortWrapper == null)
                throw new ArgumentNullException("serialPortWrapper");
            _serialPortWrapper = serialPortWrapper;

            _serialPortWrapper.StartSerialCommunication();
        }

        public ArduinoCommunicationService() : this (new SerialPortWrapper()) { }

        public long ReadIncomingData()
        {
            var message = _serialPortWrapper.ReadSerialMessage();
            if (string.IsNullOrWhiteSpace(message))
                return -1;

            var sb = new StringBuilder();
            var splits = message.Split(new char[] { ' ', '\r' });
            foreach (var split in splits)
            {
                if (string.IsNullOrWhiteSpace(split))
                    continue;

                sb.Append(Convert.ToInt32(split, 16).ToString());
            }

            return long.Parse(sb.ToString());
        }

        public void CloseSerialPort()
        {
            _serialPortWrapper.StopSerialCommunictaion();
        }

        public void SendWebApiResponse(bool isValid)
        {
            if (isValid)
                _serialPortWrapper.WriteSerialMessage("1");
            else
                _serialPortWrapper.WriteSerialMessage("0");
        }
    }
}
