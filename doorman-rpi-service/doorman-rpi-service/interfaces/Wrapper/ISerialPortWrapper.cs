namespace doorman_rpi_service.interfaces.wrapper
{
    public interface ISerialPortWrapper
    {
        string ReadSerialMessage();
        void WriteSerialMessage(string message);
        void StartSerialCommunication();
        void StopSerialCommunictaion();
    }
}
