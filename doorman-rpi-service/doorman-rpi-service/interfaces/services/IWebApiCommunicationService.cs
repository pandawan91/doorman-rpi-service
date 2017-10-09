namespace doorman_rpi_service.interfaces.services
{
    using System.Threading.Tasks;

    public interface IWebApiCommunicationService
    {
        Task<bool> ValidateCardId(long cardId);
    }
}
