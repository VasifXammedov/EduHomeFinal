using EDUHOME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewModels
{
    public class ContactVM
    {
        public Map Map { get; set; }
        public List<Address> Addresses { get; set; }
        public Message Message { get; set; }
    }
}
