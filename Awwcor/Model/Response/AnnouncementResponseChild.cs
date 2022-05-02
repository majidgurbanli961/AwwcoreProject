using System.Collections.Generic;

namespace Awwcor.Model.Response
{
    public class AnnouncementResponseChild :AnnouncementResponseParent
    {
        public string Description { get; set; }
        public List<string> AllImages { get; set; }
    }
}
