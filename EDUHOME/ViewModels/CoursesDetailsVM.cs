using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class CoursesDetailsVM
    {
        public Course Course { get; set; }
        public CourseDetail CourseDetail { get; set; }

       
        public List<Categories> Categories { get; set; } 
        public List<LatestPostDetail> LatestPostDetails { get; set; } 
        public List<TagsDetail> TagsDetails { get; set; } 
        public Message Message { get; set; } 


      

    }
}
