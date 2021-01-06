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
    public class SubscribeViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public SubscribeViewComponent(AppDbContext db )
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await Task.FromResult(_db.Subscribers.FirstOrDefault()));
        }
    }
}
