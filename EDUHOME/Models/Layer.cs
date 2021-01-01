using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class Layer  //==Home Event===//
    {
        public int Id { get; set; }
        public int Day { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? OrganizedDay { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [Required]
        public string PlacedArea { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

        public LatestPostDetail LatestPostDetail { get; set; }
    }
}
