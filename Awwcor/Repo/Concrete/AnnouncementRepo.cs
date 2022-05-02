using Awwcor.Data.Context;
using Awwcor.Data.Entities;
using Awwcor.Errors;
using Awwcor.Repo.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awwcor.Repo.Concrete
{
    public class AnnouncementRepo : IAnnouncementRepo
    {
        private readonly AwwDbContext dbContext;

        public AnnouncementRepo(AwwDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Announcement> CreateAnnouncement(Announcement announcement)
        {
            await dbContext.Announcements.AddAsync(announcement);
            var result = await dbContext.SaveChangesAsync();
            if(result <= 0)
            {
                throw new CustomError("create_announcement_error");
            }
            return announcement;
            
        }

        public async Task<List<Announcement>> GetAllAnnouncement(int page, string priceSort, string dateSort)
        {
            List<Announcement> announcements = null;
            if(priceSort=="desc"&& dateSort == "desc")
            {
                 announcements = await dbContext.Announcements.Include(x=>x.Photos).OrderByDescending(x => x.PublicDate.Date).ThenByDescending(x => x.Price).Skip(page * 10).Take(10).ToListAsync();
            }
            else if (priceSort == "asc" && dateSort == "asc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderBy(x => x.PublicDate.Date).ThenBy(x => x.Price).Skip(page * 10).Take(10).ToListAsync();
            }
            else if (priceSort == "desc" && dateSort == "asc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderBy(x => x.PublicDate.Date).ThenByDescending(x => x.Price).Skip(page * 10).Take(10).ToListAsync();
            }
            else if (priceSort == "asc" && dateSort == "desc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderByDescending(x => x.PublicDate.Date).ThenBy(x => x.Price).Skip(page * 10).Take(10).ToListAsync();

            }else if(priceSort == "asc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderBy(x => x.Price).Skip(page*10).Take(10).ToListAsync();

            }
            else if (priceSort == "desc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderByDescending(x => x.Price).Skip(page * 10).Take(10).ToListAsync();

            }
            else if(dateSort == "asc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderBy(x => x.PublicDate.Date).Skip(page * 10).Take(10).ToListAsync();

            }
            else if (dateSort == "desc")
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).OrderByDescending(x => x.PublicDate.Date).Skip(page * 10).Take(10).ToListAsync();

            }
            else
            {
                announcements = await dbContext.Announcements.Include(x => x.Photos).Skip(page * 10).Take(10).ToListAsync();
            }
            
            return announcements;

        }

        public async Task<Announcement> GetAnnouncement(int id)
        {
            var announcement = await dbContext.Announcements.Include(x=>x.Photos).FirstOrDefaultAsync(x => x.Id == id);
            if(announcement == null)
            {
                throw new CustomError("announcement_not_found");
            }
            return announcement;
        }
    }
}
