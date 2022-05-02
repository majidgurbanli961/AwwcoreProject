using Awwcor.Data.Entities;
using Awwcor.Model.Request;
using Awwcor.Model.Response;
using System.Threading.Tasks;

namespace Awwcor.Service
{
    public interface IAnnouncementService
    {
        public Task<Announcement> CreateAnnouncement(AnnouncementRequest announcementRequest);
        public  Task<ListAnnouncementResponse> GetAllAnnouncement(int? page, string priceAsc, string dateAsc);
        public Task<dynamic> GetAnnouncement(int? id, bool fields);
    }
}
