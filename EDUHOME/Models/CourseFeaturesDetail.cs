using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class CourseFeaturesDetail
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        public DateTime? Starts { get; set; }
        public string Duration { get; set; }
        public string ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public string Student { get; set; }
        public double CourseFee { get; set; }
        public bool IsDeleted { get; set; }
    }
}
