namespace doorman_rpi_service.implementations.wrapper
{
    using factories;
    using interfaces.wrapper;
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SerialPortWrapper : ISerialPortWrapper
    {
        private readonly SerialPort _serialPort;

        public SerialPortWrapper(SerialPort serialPort)
        {
            if (serialPort == null)
                throw new ArgumentNullException("serialPort");
            _serialPort = serialPort;
        }

        public SerialPortWrapper() : this(SerialPortFactory.Create("/dev/ttyACM0")) { }
        //public SerialPortWrapper() : this(SerialPortFactory.Create("COM3")) { }

        public string ReadSerialMessage()
        {
            var receivedMessage = _serialPort.ReadLine();
            if (string.IsNullOrWhiteSpace(receivedMessage))
            {
                return string.Empty;
            }
            else
                return receivedMessage;
        }
        public void WriteSerialMessage(string message)
        {
            _serialPort.WriteLine(message);
        }

        public void StartSerialCommunication()
        {
            _serialPort.Open();
        }

        public void StopSerialCommunictaion()
        {
            _serialPort.Close();
        }
    }
}
