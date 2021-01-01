using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class TeacherDetailsVM
    {
        public Teacher Teacher { get; set; }
        public List<TeacherDetail> TeacherDetails { get; set; }

        public KamranTeacherDetail KamranTeacherDetail { get; set; }
        public ContactTeacherDetail ContactTeacherDetail { get; set; }
        public List<SkillsTeacherDetail> SkillsTeacherDetails { get; set; }
       
    }
}
