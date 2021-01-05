using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class CourseTag
    {
        public int Id { get; set; }
        [ForeignKey("TagsDetail")]
        public int TagsDetailId { get; set; }
        public virtual TagsDetail TagsDetail { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
