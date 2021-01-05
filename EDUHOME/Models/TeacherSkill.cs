using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }

        [ForeignKey("SkillsTeacherDetail")]
        public int SkillsTeacherDetailId { get; set; }
        public virtual SkillsTeacherDetail SkillsTeacherDetail { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
