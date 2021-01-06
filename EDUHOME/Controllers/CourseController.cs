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

        #region Detail

        public IActionResult Detail(int? id)
        {
            CoursesDetailsVM coursesDetails = new CoursesDetailsVM
            {
                CourseDetail = _db.CourseDetails.Include(d => d.Course).FirstOrDefault(c => c.CourseId == id),
                Course = _db.Courses.Where(c => c.HasDeleted == false).Include(c => c.CourseTag).
                 ThenInclude(c => c.TagsDetail).FirstOrDefault(c => c.Id == id)
            };


            return View(coursesDetails);
        }

        #endregion

        #region Search Page

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["GetCourses"] = searchString;
            var courseQuery = from x in _db.Courses select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                courseQuery = courseQuery.Where(x => x.Name.Contains(searchString) && x.HasDeleted == false);
                return View(await courseQuery.AsNoTracking().ToListAsync());
            }
            else
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
            }


        }
    }
}
        #endregion

