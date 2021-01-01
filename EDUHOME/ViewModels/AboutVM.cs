using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class AboutVM
    {
        public List<WelcomeToEdu> WelcomeToEdus { get; set; }
        public List<AboutCarousel> AboutCarousels { get; set; }
        public List<AboutNotice> AboutNotices { get; set; }
        public List<AboutVideo> AboutVideos { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherDetail> TeacherDetail { get; set; }
       
    }
}
