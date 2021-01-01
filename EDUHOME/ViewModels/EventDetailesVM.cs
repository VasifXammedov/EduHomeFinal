using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class EventDetailesVM
    {
        public Message Message { get; set; }
        public List<TagsDetail> TagsDetails { get; set; }
        public Layer Layer { get; set; }
        public List<Categories> Categories { get; set; }
        public LatestPostDetail LatestPostDetail { get; set; }
        public List<BestDetailesWorkshop> BestDetailesWorkshops { get; set; }
        public List<SpeakerBest> SpeakerBests { get; set; }
    }
}
