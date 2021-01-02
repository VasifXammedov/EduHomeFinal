using EDUHOME.DAL;
using EDUHOME.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHOME.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(AppDbContext db,
            UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.UserFullname = String.Empty;
            if (User.Identity.IsAuthenticated)
            {
                string fullname = (await _userManager.FindByNameAsync(User.Identity.Name)).Fullname;
                ViewBag.UserFullname = fullname;
            }

            Bio model = _db.Bios.Where(b=>b.IsDeleted==false).FirstOrDefault();
            return View(await Task.FromResult(model));
        } 
             


    }
}
