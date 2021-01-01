using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.Models;
using EDUHOME.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EDUHOME.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
           
        {
            ContactVM contactVM = new ContactVM
            {
                Map = _db.Maps.Where(m => m.IsDeleted == false).FirstOrDefault(),
                Addresses=_db.Addresses.Where(a=>a.IsDeleted==false).ToList(),
                Message=_db.Messages.Where(me=>me.IsDeleted==false).FirstOrDefault()

            };
            
            return View(contactVM);
        }
    }
}
