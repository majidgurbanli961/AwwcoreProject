using Awwcor.Data.Context;
using Awwcor.Data.Entities;
using Awwcor.Errors;
using Awwcor.Repo.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Awwcor.Repo.Concrete
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly AwwDbContext dbContext;

        public PhotoRepo(AwwDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Photo> CreatePhoto(Photo photo)
        {
            await dbContext.Photos.AddAsync(photo);
            var result = await dbContext.SaveChangesAsync();
            if (result <= 0)
            {
                throw new CustomError("create_photo_error");
            }
            return photo;
        }

        public async Task<Photo> GetPhotoByUrl(string urlName)
        {
            var photo = await dbContext.Photos.FirstOrDefaultAsync(x=>x.ImageUrl == urlName);
            return photo;
        }
    }
}
