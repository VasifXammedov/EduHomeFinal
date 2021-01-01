using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Notice> Notices { get; set; }
        public List<Profession> Professions { get; set; }
        public Choose Choose { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseDetail> CourseDetails { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Carousel> Carousels { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<BlogDetail> BlogDetails { get; set; }
        public List<LatestPostDetail> LatestPostDetails { get; set; }
        
        //public List<Bio> Bios { get; set; }

    }
}
