using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class SkillsTeacherDetail
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public double Rate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }

        public ICollection<TeacherSkill> TeacherSkill { get; set; }
    }
}
