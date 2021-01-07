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

    public class WelcomeToEdusController : Controller
    {
        private readonly AppDbContext _context;

        public WelcomeToEdusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/WelcomeToEdus
        public async Task<IActionResult> Index()
        {
            return View(await _context.WelcomeToEdus.ToListAsync());
        }

        #region Details

        // GET: Admin/WelcomeToEdus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomeToEdu = await _context.WelcomeToEdus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcomeToEdu == null)
            {
                return NotFound();
            }

            return View(welcomeToEdu);
        }

        #endregion

        #region Create

        // GET: Admin/WelcomeToEdus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WelcomeToEdus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Title,Description,IsDeleted,TimeDeleted")] WelcomeToEdu welcomeToEdu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(welcomeToEdu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(welcomeToEdu);
        }

        #endregion

        #region Edit

        // GET: Admin/WelcomeToEdus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomeToEdu = await _context.WelcomeToEdus.FindAsync(id);
            if (welcomeToEdu == null)
            {
                return NotFound();
            }
            return View(welcomeToEdu);
        }

        // POST: Admin/WelcomeToEdus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Title,Description,IsDeleted,TimeDeleted")] WelcomeToEdu welcomeToEdu)
        {
            if (id != welcomeToEdu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welcomeToEdu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelcomeToEduExists(welcomeToEdu.Id))
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
            return View(welcomeToEdu);
        }

        #endregion

        #region Delete

        // GET: Admin/WelcomeToEdus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomeToEdu = await _context.WelcomeToEdus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcomeToEdu == null)
            {
                return NotFound();
            }

            return View(welcomeToEdu);
        }

        // POST: Admin/WelcomeToEdus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welcomeToEdu = await _context.WelcomeToEdus.FindAsync(id);
            _context.WelcomeToEdus.Remove(welcomeToEdu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WelcomeToEduExists(int id)
        {
            return _context.WelcomeToEdus.Any(e => e.Id == id);
        }

        #endregion

    }
}
