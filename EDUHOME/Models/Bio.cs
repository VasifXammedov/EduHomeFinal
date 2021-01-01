using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class Bio
    {
        public int Id { get; set; }
        [Required]
        public string HeaderLogo { get; set; }
        [Required]
        public  string FooterLogo { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Pinterset { get; set; }
        public string Vimeo { get; set; }
        public string Twitter { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
