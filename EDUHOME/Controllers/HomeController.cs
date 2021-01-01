using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EDUHOME.Models;
using EDUHOME.ViewModels;
using EDUHOME.DAL;
using Microsoft.EntityFrameworkCore;

namespace EDUHOME.Controllers
{
    public class HomeController : Controller
    {  
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _db.Sliders.Where(s=>s.IsDeleted==false).ToList(),
                Notices=_db.Notices.Where(n=>n.IsDeleted==false).ToList(),
                Professions=_db.Professions.Where(p=>p.IsDeleted==false).ToList(),
                Choose=_db.Chooses.Where(c=>c.IsDeleted==false).FirstOrDefault(),
                Courses = _db.Courses.Where(c=>c.HasDeleted==false).Take(3).ToList(),
                Carousels=_db.Carousels.Where(c=>c.IsDeleted==false).ToList(),
                Blogs=_db.Blogs.Where(b=>b.HasDeleted==false).Take(3).ToList(),
                LatestPostDetails=_db.LatestPostDetails.Where(l=>l.IsDeleted==false).ToList()

            };
            return View(homeVM);
        }

    }
}
