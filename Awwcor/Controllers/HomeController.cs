using Awwcor.Model.Request;
using Awwcor.Model.Response;
using Awwcor.Response;
using Awwcor.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Awwcor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAnnouncementService announcementService;

        public HomeController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }
        [HttpPost("create")]
        public async Task<ApiValueResponse<AnnouncementCreateResponse>> CreateAnnouncement(AnnouncementRequest announcementRequest)
        {
            var announcement = await announcementService.CreateAnnouncement(announcementRequest);
            AnnouncementCreateResponse response = new AnnouncementCreateResponse();
            response.Id = announcement.Id;
            return new ApiValueResponse<AnnouncementCreateResponse>(response);
        }
        [HttpGet("getall")]
        public async Task <ApiValueResponse<ListAnnouncementResponse>> GetAllAnnouncement(int? page, string priceAsc , string dateAsc)
        {
            var response = await announcementService.GetAllAnnouncement(page, priceAsc, dateAsc);

            return new ApiValueResponse<ListAnnouncementResponse>(response);
        }
        [HttpGet("getparticular")]
        public async Task<dynamic> GetParticularAnnouncement(int? id , bool fields )
        {
            var response =  await announcementService.GetAnnouncement(id, fields);
            if (fields)
            {
                return new ApiValueResponse<AnnouncementResponseChild>(response);


            }
            return new ApiValueResponse<AnnouncementResponseParent>(response);



        }

    }
}
