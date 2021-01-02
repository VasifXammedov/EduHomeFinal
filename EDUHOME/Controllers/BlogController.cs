using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.Models;
using EDUHOME.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDUHOME.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_db.Blogs.Where(b => b.HasDeleted == false).Count() / 3);
            ViewBag.page = page;
            if (page == null)
            {
                List<Blog> Blogs = _db.Blogs.Where(b => b.HasDeleted == false).Take(3).ToList();
                return View(Blogs);
            }
            List<Blog> blogs = _db.Blogs.Where(b => b.HasDeleted == false).Skip((int)(page - 1) * 3).Take(3).ToList();
            return View(blogs);

            //List<Blog> blogs = _db.Blogs.Where(b => b.HasDeleted == false).ToList();
            //return View(blogs);


        }
        
       

        public IActionResult Detail(int? id)
        {
            BlogDetailesVM blogDetailesVM = new BlogDetailesVM
            {
               

                Blog=_db.Blogs.Where(b=>b.HasDeleted==false&&b.Id==id).Include(b=>b.BlogDetail).FirstOrDefault(),
                Message = _db.Messages.Where(me => me.IsDeleted == false).FirstOrDefault(),
                TagsDetails = _db.TagsDetails.Where(t => t.IsDeleted == false).ToList(),
                Categories = _db.Categories.Where(cat => cat.IsDeleted).ToList(),
                LatestPostDetails = _db.LatestPostDetails.Where(l => l.IsDeleted == false).ToList(),
                BestDetailesWorkshop = _db.BestDetailesWorkshops.Where(b => b.IsDeleted == false).FirstOrDefault(),
                SpeakerBests = _db.SpeakerBests.Where(s => s.IsDeleted == false).ToList()
            };
            return View(blogDetailesVM);
        }
    }
}
