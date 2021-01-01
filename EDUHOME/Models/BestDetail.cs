using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class BestDetail
    {

        // Bu demek olarki lazim olmadi

        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
