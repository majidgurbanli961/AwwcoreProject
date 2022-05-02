using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awwcor.Data.Entities
{
    [Table("Photos")]

    public class Photo
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("image_url")]

        public string ImageUrl { get; set; }
        [Column("announcement_id")]

        public int? AnnouncementId { get;set; }
        public Announcement Announcement { get; set; }
    }
}
