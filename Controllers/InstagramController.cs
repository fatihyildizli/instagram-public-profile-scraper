using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stalker.DTO;
using Stalker.Services;

namespace Stalker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstagramController : ControllerBase
    {

        readonly IInstagramService _instagramService;
        IConfiguration _iconfiguration;

        public InstagramController(IInstagramService instagramService, IConfiguration iconfiguration)
        {
            _instagramService = instagramService;
            _iconfiguration = iconfiguration;
        }

  
        [Route("GetStatsFromJS")]
        [HttpPost]
        public InstagramAccountResponseDTO GetInstagramStatsFromJS(InstagramAccountRequestDTO req)
        {

            return _instagramService.GetInstagramStatsFromJS(req);
        }

    }
}
