using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public EventController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.LatestPostDetails.Where(c => c.IsDeleted == false).OrderByDescending(c => c.Id).ToList());
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LatestPostDetail events)
        {
            //if (!ModelState.IsValid) return View();
            bool isExist = _db.LatestPostDetails.Where(c => c.IsDeleted == false)
                   .Any(c => c.Title.ToLower() == events.Title.ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu event artiq movcuddur");
                return View();
            }
            if (events.Photo == null)
            {
                ModelState.AddModelError("", "Ayeee wekili elave ele!!!");
                return View();
            }
            if (!events.Photo.IsImage())
            {
                ModelState.AddModelError("", "Event yaratmaq ucun wekil tipi yarat!!!");
                return View();
            }
            if (!events.Photo.MaxSize(200))
            {
                ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                return View();
            }

            string folder = Path.Combine("assets", "img", "event");
            string fileName = await events.Photo.SaveImgAsync(_env.WebRootPath, folder);
            events.Image = fileName;
            events.IsDeleted = false;
            await _db.LatestPostDetails.AddAsync(events);


            List<Subscriber> emails = _db.Subscribers.ToList();
            foreach (Subscriber email in emails)
            {
                SendEmail(email.Email, "Yeni bir event yaradildi.", "<h1>Yeni bir event yaradildi</h1>");
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Deleted

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            LatestPostDetail events = _db.LatestPostDetails
                .FirstOrDefault(c => c.IsDeleted == false && c.Id == id);
            if (events == null) return NotFound();
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            LatestPostDetail events = _db.LatestPostDetails
                .FirstOrDefault(c => c.IsDeleted == false && c.Id == id);
            if (events == null) return NotFound();
            events.IsDeleted = true;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            LatestPostDetail events = _db.LatestPostDetails
                .FirstOrDefault(c => c.IsDeleted == false && c.Id == id);
            if (events == null) return NotFound();
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, LatestPostDetail events)
        {
            LatestPostDetail viewEvents = _db.LatestPostDetails.Include(c => c.BestDetailesWorkshop).FirstOrDefault(c => c.Id == id && c.IsDeleted == false);
           
            if (events.Photo != null)
            {
                if (!events.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Event yaratmaq ucun wekil tipi yarat!!!");
                    return View(viewEvents);
                }
                if (!events.Photo.MaxSize(200))
                {
                    ModelState.AddModelError("", "Wekilin olcusu 200kb-dan az olmalidi!!!");
                    return View(viewEvents);
                }

                string folder = Path.Combine("assets", "img", "event");
                string fileName = await events.Photo.SaveImgAsync(_env.WebRootPath, folder);
                viewEvents.Image = fileName;
            }
           
            viewEvents.IsDeleted = false;
            viewEvents.Title = events.Title;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        #endregion

        #region Detail


        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            LatestPostDetail events = _db.LatestPostDetails
                .FirstOrDefault(c => c.IsDeleted == false && c.Id == id);
            if (events == null) return NotFound();
            return View(events);

        }

        #endregion


        public void SendEmail(string email, string subject, string htmlMessage)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "vasif.xammedov.code@gmail.com",
                    Password = "mustafa2000"
                }
            };
            MailAddress fromEmail = new MailAddress("vasif.xammedov.code@gmail.com", "Vasif");
            MailAddress toEmail = new MailAddress(email, "Vasif");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = subject,
                Body = htmlMessage
            };
            message.To.Add(toEmail);
            client.Send(message);
        }

    }
}
