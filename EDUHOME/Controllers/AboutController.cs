using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDUHOME.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                WelcomeToEdus=_db.WelcomeToEdus.Where(we=>we.IsDeleted==false).ToList(),
                AboutCarousels=_db.AboutCarousels.Where(ab=>ab.IsDeleted==false).ToList(),
                AboutNotices=_db.AboutNotices.Where(an=>an.IsDeleted==false).ToList(),
                AboutVideos=_db.AboutVideos.Where(av=>av.IsDeleted==false).ToList(),
                Teachers = _db.Teachers.Take(4).Where(t => t.IsDeleted == false).ToList()
            };
            return View(aboutVM);
        }
    }
}
