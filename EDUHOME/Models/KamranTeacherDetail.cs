using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class KamranTeacherDetail
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        public string Profesiya { get; set; }
        [Required,StringLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string degree { get; set; }
        public string experience { get; set; }
        public string hobbies { get; set; }
        public string faculty { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
