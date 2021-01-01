using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class BestDetailesWorkshop  //===Event-Detail====//==Adi budu==//
    {

        //Buda demek olarki lazim olmadi

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

        [ForeignKey("LatestPostDetail")]
        public int LatestPostDetailId { get; set; }
        public LatestPostDetail LatestPostDetail { get; set; }
    }
}
