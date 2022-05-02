using System.Collections.Generic;

namespace Awwcor.Model.Response
{
    public class ConditionalAnnouncementResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public List<string> AllImages { get; set; }
        public bool IsDetail { get; set; }
        public bool ShouldSerializeDescription() => IsDetail;
        public bool ShouldSerializeAllImages() => IsDetail;



    }
}
