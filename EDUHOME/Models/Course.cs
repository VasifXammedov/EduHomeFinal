using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

        public CourseDetail CourseDetail { get; set; }
       
        //public CourseDetailEncineering CourseDetailEncineering { get; set; }
        //public int CourseDetailEncineeringId { get; set; }

    }
}
