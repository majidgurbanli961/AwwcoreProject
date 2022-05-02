using Awwcor.Data.Entities;
using Awwcor.Model.Request;
using Awwcor.Model.Response;
using Awwcor.Repo.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Awwcor.Service.Concrete
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IPhotoRepo photoRepo;
        private readonly IAnnouncementRepo announcementRepo;

        public AnnouncementService(IPhotoRepo photoRepo,IAnnouncementRepo announcementRepo)
        {
            this.photoRepo = photoRepo;
            this.announcementRepo = announcementRepo;
        }
        public async Task<Announcement> CreateAnnouncement(AnnouncementRequest announcementRequest)
        {
            List<Photo> photos = new List<Photo>();
            foreach (var photoLink in announcementRequest.PhotoLinks)
            {
             
                    Photo photoWithoutId = new Photo() { ImageUrl=photoLink};
                    var photo = await photoRepo.CreatePhoto(photoWithoutId);
                
                photos.Add(photo);
            }
            Announcement announcement = new Announcement() { Description=announcementRequest.Description,Photos=photos,Price=announcementRequest.Price, PublicDate=System.DateTime.Now};
           var resultAnnouncement =  await   announcementRepo.CreateAnnouncement(announcement);
            return resultAnnouncement;




        }
        public async Task<ListAnnouncementResponse> GetAllAnnouncement(int? page , string priceAsc , string dateAsc)
        {
            int pageNotNull;
            if(page == null)
            {
                pageNotNull = (int) 0;
            }
            else
            {
                pageNotNull = (int) page;
            }
            var announcements = await announcementRepo.GetAllAnnouncement(pageNotNull, priceAsc, dateAsc);
            ListAnnouncementResponse response = new ListAnnouncementResponse();

            List<AnnouncementResponse> announcementResponses = new List<AnnouncementResponse>();
            if(announcements == null) {
                return response;
            }
            foreach (var announcement in announcements)
            {
                AnnouncementResponse announcementResponse = new AnnouncementResponse() { Name = announcement.Name, Price=announcement.Price, Date=announcement.PublicDate };
                string imageUrl = null;
                if(announcement.Photos.Count > 0)
                {
                    imageUrl = announcement.Photos[0].ImageUrl;

                }
                announcementResponse.ImageUrl = imageUrl;
                announcementResponses.Add(announcementResponse);

            }
            response.AnnouncementResponses = announcementResponses;
            return response;

        }

        public async Task<dynamic> GetAnnouncement(int? id, bool fields)
        {
            int pageNotNull;
            if (id == null)
            {
                pageNotNull = (int)0;
            }
            else
            {
                pageNotNull = (int)id;
            }
            var announcement = await announcementRepo.GetAnnouncement(pageNotNull);

            string mainPhotoUrl = null;
            List<string> photos = new List<string>();
            if (announcement.Photos.Count > 0)
            {
                mainPhotoUrl = announcement.Photos[0].ImageUrl;
                foreach (var photo in announcement.Photos)
                {
                    photos.Add(photo.ImageUrl);
                }

            }
            AnnouncementResponseChild response = new AnnouncementResponseChild() ;
           
                response.Name = announcement.Name;
                response.MainImage = mainPhotoUrl;
                response.Price = announcement.Price;
            response.Description = announcement.Description;
            response.AllImages = photos;
            if (fields)
            {
                return response;

            }

                AnnouncementResponseParent response2 = response;
                return response2;
               
               
            



            //ConditionalAnnouncementResponse response = new ConditionalAnnouncementResponse() { Name=announcement.Name, MainImage= mainPhotoUrl, AllImages= photos, Description= announcement.Description, Price = announcement.Price, IsDetail=fields };

           
                 
        }
    }
}
