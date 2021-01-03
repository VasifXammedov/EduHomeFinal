using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.Extensions;
using EDUHOME.Helpers;
using EDUHOME.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDUHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CourseController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Courses.Where(c => c.HasDeleted == false).OrderByDescending(c => c.Id).ToList());
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            //if (!ModelState.IsValid) return View();
            bool isExist = _db.Courses.Where(c => c.HasDeleted == false)
                   .Any(c => c.Name.ToLower() == course.Name.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu kurs artiq movcuddur");
                return View();
            }
            if (course.Photo == null)
            {
                ModelState.AddModelError("", "Ayeee wekili elave ele!!!");
                return View();
            }
            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("", "Kurs yaratmaq ucun wekil tipi yarat!!!");
                return View();
            }
            if (!course.Photo.MaxSize(200))
            {
                ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                return View();
            }

            string folder = Path.Combine("assets", "img","course");
            string fileName = await course.Photo.SaveImgAsync(_env.WebRootPath, folder);
            course.Image = fileName;
            course.HasDeleted = false;
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Deleted

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (course == null) return NotFound();
            course.HasDeleted = true;
           
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course)
        {
            Course viewCourse = _db.Courses.Include(c => c.CourseDetail).FirstOrDefault(c => c.Id == id && c.HasDeleted == false);
           
            if (course.Photo != null)
            {
                if (!course.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Kurs yaratmaq ucun wekil tipi yarat!!!");
                    return View(viewCourse);
                }
                if (!course.Photo.MaxSize(200))
                {
                    ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                    return View(viewCourse);
                }

                string folder = Path.Combine("assets", "img", "course");
                string fileName = await course.Photo.SaveImgAsync(_env.WebRootPath, folder);
                course.Image = fileName;
            }
           
            course.HasDeleted = false;
            viewCourse.Name = course.Name;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        #endregion

        #region Detail


        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (course == null) return NotFound();
            return View(course);

        }

        #endregion

    }
}
