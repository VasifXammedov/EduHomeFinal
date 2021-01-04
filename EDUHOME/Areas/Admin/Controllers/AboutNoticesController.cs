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
    public class AboutNoticesController : Controller
    {
        private readonly AppDbContext _context;

        public AboutNoticesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AboutNotices
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutNotices.ToListAsync());
        }

        // GET: Admin/AboutNotices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutNotice = await _context.AboutNotices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutNotice == null)
            {
                return NotFound();
            }

            return View(aboutNotice);
        }

        // GET: Admin/AboutNotices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutNotices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,IsDeleted,TimeDeleted")] AboutNotice aboutNotice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutNotice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutNotice);
        }

        // GET: Admin/AboutNotices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutNotice = await _context.AboutNotices.FindAsync(id);
            if (aboutNotice == null)
            {
                return NotFound();
            }
            return View(aboutNotice);
        }

        // POST: Admin/AboutNotices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsDeleted,TimeDeleted")] AboutNotice aboutNotice)
        {
            if (id != aboutNotice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutNotice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutNoticeExists(aboutNotice.Id))
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
            return View(aboutNotice);
        }

        // GET: Admin/AboutNotices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutNotice = await _context.AboutNotices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutNotice == null)
            {
                return NotFound();
            }

            return View(aboutNotice);
        }

        // POST: Admin/AboutNotices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutNotice = await _context.AboutNotices.FindAsync(id);
            _context.AboutNotices.Remove(aboutNotice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutNoticeExists(int id)
        {
            return _context.AboutNotices.Any(e => e.Id == id);
        }
    }
}
