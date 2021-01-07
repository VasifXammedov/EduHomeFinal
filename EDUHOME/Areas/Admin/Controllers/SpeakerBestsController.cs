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

    public class SpeakerBestsController : Controller
    {
        private readonly AppDbContext _context;

        public SpeakerBestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SpeakerBests
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpeakerBests.ToListAsync());
        }


        #region Details

        // GET: Admin/SpeakerBests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerBest = await _context.SpeakerBests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speakerBest == null)
            {
                return NotFound();
            }

            return View(speakerBest);
        }

        #endregion

        #region Create

        // GET: Admin/SpeakerBests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SpeakerBests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,Profesiya,IsDeleted,DeletedTime")] SpeakerBest speakerBest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speakerBest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speakerBest);
        }

        #endregion

        #region Edit

        // GET: Admin/SpeakerBests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerBest = await _context.SpeakerBests.FindAsync(id);
            if (speakerBest == null)
            {
                return NotFound();
            }
            return View(speakerBest);
        }

        // POST: Admin/SpeakerBests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Profesiya,IsDeleted,DeletedTime")] SpeakerBest speakerBest)
        {
            if (id != speakerBest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speakerBest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerBestExists(speakerBest.Id))
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
            return View(speakerBest);
        }


        #endregion

        #region Delete

        // GET: Admin/SpeakerBests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speakerBest = await _context.SpeakerBests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speakerBest == null)
            {
                return NotFound();
            }

            return View(speakerBest);
        }

        // POST: Admin/SpeakerBests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakerBest = await _context.SpeakerBests.FindAsync(id);
            _context.SpeakerBests.Remove(speakerBest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerBestExists(int id)
        {
            return _context.SpeakerBests.Any(e => e.Id == id);
        }

        #endregion

    }
}
