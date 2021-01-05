using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Name { get; set; }
        public string Profesia { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

        public TeacherDetail TeacherDetail { get; set; }

        public ICollection<TeacherSkill> TeacherSkill { get; set; }

    }
}
