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
    //[Authorize(Rolse="Admin")]

    public class AboutCarouselsController : Controller
    {
        private readonly AppDbContext _context;

        public AboutCarouselsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AboutCarousels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutCarousels.ToListAsync());
        }


        #region Detail

        // GET: Admin/AboutCarousels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutCarousel = await _context.AboutCarousels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutCarousel == null)
            {
                return NotFound();
            }

            return View(aboutCarousel);
        }

        #endregion

        #region Create

        // GET: Admin/AboutCarousels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutCarousels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Description,Name,Title,IsDeleted,TimeDeleted")] AboutCarousel aboutCarousel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutCarousel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutCarousel);
        }


        #endregion

        #region Edit

        // GET: Admin/AboutCarousels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutCarousel = await _context.AboutCarousels.FindAsync(id);
            if (aboutCarousel == null)
            {
                return NotFound();
            }
            return View(aboutCarousel);
        }

        // POST: Admin/AboutCarousels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Description,Name,Title,IsDeleted,TimeDeleted")] AboutCarousel aboutCarousel)
        {
            if (id != aboutCarousel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutCarousel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutCarouselExists(aboutCarousel.Id))
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
            return View(aboutCarousel);
        }

        #endregion

        #region Delete

        // GET: Admin/AboutCarousels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutCarousel = await _context.AboutCarousels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutCarousel == null)
            {
                return NotFound();
            }

            return View(aboutCarousel);
        }

        // POST: Admin/AboutCarousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutCarousel = await _context.AboutCarousels.FindAsync(id);
            _context.AboutCarousels.Remove(aboutCarousel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutCarouselExists(int id)
        {
            return _context.AboutCarousels.Any(e => e.Id == id);
        }

        #endregion

    }
}
