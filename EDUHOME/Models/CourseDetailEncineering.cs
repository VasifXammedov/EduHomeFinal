using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class CourseDetailEncineering
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required, StringLength(50)]
        public string BigTitle { get; set; }
        public string BigDescription { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        //public Course Course { get; set; }
        //public int CourseId { get; set; }
    }
}
