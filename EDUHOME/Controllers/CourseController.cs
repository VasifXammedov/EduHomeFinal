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
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db)
        {
            _db = db;
        }
        public  IActionResult Index(int? page)
        {

            ViewBag.PageCount = Decimal.Ceiling((decimal)_db.Courses.Where(b => b.HasDeleted == false).Count() / 3);
            ViewBag.page = page;
            if (page == null)
            {
                List<Course> Courses = _db.Courses.Where(b => b.HasDeleted == false).Take(3).ToList();
                return View(Courses);
            }
            List<Course> courses = _db.Courses.Where(b => b.HasDeleted == false).Skip((int)(page - 1) * 3).Take(3).ToList();
            return View(courses);
            //List<Course> courses = _db.Courses.Where(c=>c.HasDeleted==false).ToList();
            //return View(courses);
        }

        public IActionResult Detail(int? id)
        {
            CourseDetail courseDetail = _db.CourseDetails.Include(d=>d.Course).FirstOrDefault(c => c.CourseId == id);
            


            return View(courseDetail);
        }
    }
}
