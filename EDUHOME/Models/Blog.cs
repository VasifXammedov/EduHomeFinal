using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime? PostedTime { get; set; }
        public int CommentsCount { get; set; }
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

// Burda hansi sehifeye gedecemse oranin mes:BlogDedail-ni cagiririq

        public BlogDetail BlogDetail { get; set; }
       
    }
}
