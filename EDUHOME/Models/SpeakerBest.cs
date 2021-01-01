using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class SpeakerBest
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,StringLength(30)]
        public string Name { get; set; }
        public string Profesiya { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
