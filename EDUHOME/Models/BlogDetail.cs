using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.Models
{
    public class BlogDetail
    {
        public int Id { get; set; }
        public string DetailedImage { get; set; }
        public string FirstContent { get; set; }
        public string SecondContent { get; set; }
        public string ThirdContent { get; set; }
        public string FourthContent { get; set; }
        public bool IsDeletedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        
        //Burda haradanki kiliknde gelecekse oranin Id-ni cagiriram

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        //=====//
       
    }
}
