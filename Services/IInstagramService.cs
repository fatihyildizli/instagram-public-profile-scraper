using Stalker.DTO;


namespace Stalker.Services
{
    public interface IInstagramService
    {
        
        InstagramAccountResponseDTO GetInstagramStatsFromJS(InstagramAccountRequestDTO req);
    }
}
