using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Awwcor.Model.Request
{
    public class AnnouncementRequest
    {
        [StringLength(200,ErrorMessage ="name_length_error")]
      
        public string Name { get; set; }
        [StringLength(1000, ErrorMessage ="description_length_error")]
        
        public string Description { get; set; }
      
        public decimal Price { get; set; }
        [MaxLengthAttribute(3,ErrorMessage ="photo_links_length_error")]
      
        public List<string> PhotoLinks { get; set; }
    }
}
