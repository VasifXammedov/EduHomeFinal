using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class BlogDetailesVM
    {
        public Message Message { get; set; }

        // Burada Blog ve BlogDetaili getirdik
        public Blog Blog { get; set; }
        public BlogDetail BlogDetail { get; set; }
        //=====//

        public List<TagsDetail> TagsDetails { get; set; }
        public List<Categories> Categories { get; set; }
        public List<LatestPostDetail> LatestPostDetails { get; set; }
        public BestDetailesWorkshop BestDetailesWorkshop { get; set; }
        public List<SpeakerBest> SpeakerBests { get; set; }
    }
}
