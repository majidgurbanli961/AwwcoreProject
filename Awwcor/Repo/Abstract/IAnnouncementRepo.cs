using Awwcor.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Awwcor.Repo.Abstract
{
    public interface IAnnouncementRepo
    {
        public Task<Announcement> CreateAnnouncement(Announcement announcement);
        public  Task<List<Announcement>> GetAllAnnouncement(int page, string priceSort, string dateSort);
        public Task<Announcement> GetAnnouncement(int id);
    }
}
