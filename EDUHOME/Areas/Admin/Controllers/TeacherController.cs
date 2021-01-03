﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.Extensions;
using EDUHOME.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EDUHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public TeacherController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Teachers.Where(c => c.IsDeleted == false).OrderByDescending(c => c.Id).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

       
        #region Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            //if (!ModelState.IsValid) return View();
            bool isExist = _db.Teachers.Where(c => c.IsDeleted == false)
                   .Any(c => c.Name.ToLower() == teacher.Name.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu kurs artiq movcuddur");
                return View();
            }
            if (teacher.Photo == null)
            {
                ModelState.AddModelError("", "Ayeee wekili elave ele!!!");
                return View();
            }
            if (!teacher.Photo.IsImage())
            {
                ModelState.AddModelError("", "Kurs yaratmaq ucun wekil tipi yarat!!!");
                return View();
            }
            if (!teacher.Photo.MaxSize(200))
            {
                ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                return View();
            }

            string folder = Path.Combine("assets", "img", "teacher");
            string fileName = await teacher.Photo.SaveImgAsync(_env.WebRootPath, folder);
            teacher.Image = fileName;
            teacher.IsDeleted = false;
            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #endregion

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _db.Teachers
                .FirstOrDefault(c => c.IsDeleted == false && c.Id == id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }


        #region Deleted

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _db.Teachers
                .FirstOrDefault(c => c.IsDeleted == false && c.Id == id);
            if (teacher == null) return NotFound();
            teacher.IsDeleted = true;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Course course = _db.Courses
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

    }
}
