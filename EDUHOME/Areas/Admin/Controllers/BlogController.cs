using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.Extensions;
using EDUHOME.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDUHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Blogs.Where(b => b.HasDeleted == false).OrderByDescending(b => b.Id).ToList());
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            //if (!ModelState.IsValid) return View();
            bool isExist = _db.Blogs.Where(c => c.HasDeleted == false)
                   .Any(b => b.Description.ToLower() == blog.Description.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu blog artiq movcuddur");
                return View();
            }
            if (blog.Photo == null)
            {
                ModelState.AddModelError("", "Ayeee wekili elave ele!!!");
                return View();
            }
            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("", "Blog yaratmaq ucun wekil tipi yarat!!!");
                return View();
            }
            if (!blog.Photo.MaxSize(200))
            {
                ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                return View();
            }

            string folder = Path.Combine("assets", "img", "blog");
            string fileName = await blog.Photo.SaveImgAsync(_env.WebRootPath, folder);
            blog.Image = fileName;
            blog.HasDeleted = false;
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Deleted

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (blog == null) return NotFound();
            blog.HasDeleted = true;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            Blog viewBlog = _db.Blogs.Include(c => c.BlogDetail).FirstOrDefault(c => c.Id == id && c.HasDeleted == false);
            bool isExist = _db.Blogs.Where(c => c.HasDeleted == false)
                   .Any(c => c.Description.ToLower() == blog.Description.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Mellim artiq movcuddur");
                return View(viewBlog);
            }
            if (blog.Photo == null)
            {
                ModelState.AddModelError("", "Ayeee wekili elave ele!!!");
                return View(viewBlog);
            }
            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("", "Bunu yaratmaq ucun wekil tipi yarat!!!");
                return View(viewBlog);
            }
            if (!blog.Photo.MaxSize(200))
            {
                ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                return View(viewBlog);
            }

            string folder = Path.Combine("assets", "img", "blog");
            string fileName = await blog.Photo.SaveImgAsync(_env.WebRootPath, folder);
            blog.Image = fileName;
            blog.HasDeleted = false;
            viewBlog.Description = blog.Description;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        #endregion

        #region Detail


        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Blog blog = _db.Blogs
                .FirstOrDefault(c => c.HasDeleted == false && c.Id == id);
            if (blog == null) return NotFound();
            return View(blog);

        }

        #endregion


    }
}
