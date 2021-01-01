using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class LatestPostDetail  //===Event===//
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public int Day { get; set; }
        public string Month { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }

        public BestDetailesWorkshop BestDetailesWorkshop { get; set; }

    }
}
