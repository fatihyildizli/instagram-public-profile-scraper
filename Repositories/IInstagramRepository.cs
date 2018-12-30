using Stalker.DTO;


namespace Stalker.Repositories
{
    public interface IInstagramRepository
    {
        InstagramAccountResponseDTO GetInstagramStatsFromJS(InstagramAccountRequestDTO req);
      
    }
}
