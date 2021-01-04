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
    public class TagsDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public TagsDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TagsDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TagsDetails.ToListAsync());
        }

        // GET: Admin/TagsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagsDetail = await _context.TagsDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagsDetail == null)
            {
                return NotFound();
            }

            return View(tagsDetail);
        }

        // GET: Admin/TagsDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TagsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,TimeDeleted")] TagsDetail tagsDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tagsDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagsDetail);
        }

        // GET: Admin/TagsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagsDetail = await _context.TagsDetails.FindAsync(id);
            if (tagsDetail == null)
            {
                return NotFound();
            }
            return View(tagsDetail);
        }

        // POST: Admin/TagsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsDeleted,TimeDeleted")] TagsDetail tagsDetail)
        {
            if (id != tagsDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tagsDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsDetailExists(tagsDetail.Id))
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
            return View(tagsDetail);
        }

        // GET: Admin/TagsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagsDetail = await _context.TagsDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagsDetail == null)
            {
                return NotFound();
            }

            return View(tagsDetail);
        }

        // POST: Admin/TagsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tagsDetail = await _context.TagsDetails.FindAsync(id);
            _context.TagsDetails.Remove(tagsDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagsDetailExists(int id)
        {
            return _context.TagsDetails.Any(e => e.Id == id);
        }
    }
}
