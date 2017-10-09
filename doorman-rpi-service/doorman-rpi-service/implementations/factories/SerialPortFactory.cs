namespace doorman_rpi_service.implementations.factories
{
    using System;
    using System.IO.Ports;

    public static class SerialPortFactory
    {
        public static SerialPort Create(string portName)
        {
            if (string.IsNullOrWhiteSpace(portName))
                throw new ArgumentNullException("portName");

            return new SerialPort()
            {
                PortName = portName,
                BaudRate = 9600
            };
        }
    }
}
