using Stalker.DTO;
using Stalker.Repositories;

namespace Stalker.Services
{
    public class InstagramService : IInstagramService
    {
        private readonly IInstagramRepository _instagramRepository;
        public InstagramService(IInstagramRepository instagramRepository)
        {
            _instagramRepository = instagramRepository;

        }
    
  
        public InstagramAccountResponseDTO GetInstagramStatsFromJS(InstagramAccountRequestDTO req)
        {

            return _instagramRepository.GetInstagramStatsFromJS(req);

        }
    }
}
