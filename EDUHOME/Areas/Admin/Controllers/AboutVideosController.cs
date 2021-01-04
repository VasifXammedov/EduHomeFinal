using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDUHOME.DAL;
using EDUHOME.Models;

namespace EDUHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutVideosController : Controller
    {
        private readonly AppDbContext _context;

        public AboutVideosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AboutVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutVideos.ToListAsync());
        }


        #region Details

        // GET: Admin/AboutVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutVideo = await _context.AboutVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutVideo == null)
            {
                return NotFound();
            }

            return View(aboutVideo);
        }

        #endregion

        #region Create

        // GET: Admin/AboutVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Youtube,IsDeleted,TimeDeleted")] AboutVideo aboutVideo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutVideo);
        }


        #endregion

        #region Edit

        // GET: Admin/AboutVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutVideo = await _context.AboutVideos.FindAsync(id);
            if (aboutVideo == null)
            {
                return NotFound();
            }
            return View(aboutVideo);
        }

        // POST: Admin/AboutVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Youtube,IsDeleted,TimeDeleted")] AboutVideo aboutVideo)
        {
            if (id != aboutVideo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutVideoExists(aboutVideo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutVideo);
        }

        #endregion

        #region Delete

        // GET: Admin/AboutVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutVideo = await _context.AboutVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutVideo == null)
            {
                return NotFound();
            }

            return View(aboutVideo);
        }

        // POST: Admin/AboutVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutVideo = await _context.AboutVideos.FindAsync(id);
            _context.AboutVideos.Remove(aboutVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutVideoExists(int id)
        {
            return _context.AboutVideos.Any(e => e.Id == id);
        }

        #endregion

    }
}
