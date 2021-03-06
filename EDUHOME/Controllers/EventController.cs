﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUHOME.DAL;
using EDUHOME.Models;
using EDUHOME.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDUHOME.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        public EventController(AppDbContext db)
        {
            _db = db;
        }

        #region Event Page Search


        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["GetLatestPostDetails"] = searchString;
            var eventQuery = from x in _db.LatestPostDetails select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                eventQuery = eventQuery.Where(x => x.Title.Contains(searchString) && x.IsDeleted == false);
                return View(await eventQuery.AsNoTracking().ToListAsync());
            }
            else
            {
                ViewBag.PageCount = Decimal.Ceiling((decimal)_db.LatestPostDetails.Where(b => b.IsDeleted == false).Count() / 3);
                ViewBag.page = page;
                if (page == null)
                {
                    List<LatestPostDetail> LatestPostDetails = _db.LatestPostDetails.Where(b => b.IsDeleted == false).Take(3).ToList();
                    return View(LatestPostDetails);
                }
                List<LatestPostDetail> latestPostDetails = _db.LatestPostDetails.Where(b => b.IsDeleted == false).Skip((int)(page - 1) * 3).Take(3).ToList();
                return View(latestPostDetails);

            }


        }


        #endregion

        #region Detail

        public IActionResult Detail(int? id)
        {
            EventDetailesVM eventDetailesVM = new EventDetailesVM
            {
                LatestPostDetail = _db.LatestPostDetails.Where(l => l.IsDeleted == false && l.Id == id).Include(l => l.BestDetailesWorkshop).FirstOrDefault(),
                Message = _db.Messages.Where(me => me.IsDeleted == false).FirstOrDefault(),
                Categories = _db.Categories.Where(cat => cat.IsDeleted).ToList(),
                BestDetailesWorkshops = _db.BestDetailesWorkshops.Where(b => b.IsDeleted == false).ToList(),
                SpeakerBests = _db.SpeakerBests.Where(s => s.IsDeleted == false).ToList()
            };

            return View(eventDetailesVM);
        }

        #endregion

    }
}
