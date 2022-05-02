using Awwcor.Data.Entities;
using System.Threading.Tasks;

namespace Awwcor.Repo.Abstract
{
    public interface IPhotoRepo
    {
        public Task<Photo> GetPhotoByUrl(string urlName);
        public Task<Photo> CreatePhoto(Photo photo);
    }
}
