using System;
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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_db.TeacherDetails.Where(b => b.IsDeleted == false).Count() / 4);
            ViewBag.page = page;
            if (page == null)
            {
                List<TeacherDetail> teacherDetail = _db.TeacherDetails.Where(b => b.IsDeleted == false).Take(4).ToList();
                return View(teacherDetail);
            }
            List<TeacherDetail> teacherDetails = _db.TeacherDetails.Where(b => b.IsDeleted == false).Skip((int)(page-1)*4).Take(4).ToList();
            return View(teacherDetails);
        }

        public IActionResult Detail(int? id)
        {
            //List<TeacherDetail> teacherDetails = _db.TeacherDetails.Where(t => t.IsDeleted == false && t.Id == id).ToList();

            TeacherDetailsVM teacherDetailsVM = new TeacherDetailsVM
            {
                //TeacherDetails = _db.TeacherDetails.Where(t => t.IsDeleted == false && t.Id == id).Include(t => t.Teacher).ToList(),
                Teacher =_db.Teachers.Where(t=>t.IsDeleted==false).Include(t=>t.TeacherDetail).FirstOrDefault(t=>t.Id == id),
                KamranTeacherDetail=_db.KamranTeacherDetails.Where(k=>k.IsDeleted==false).FirstOrDefault(),
                ContactTeacherDetail=_db.ContactTeacherDetails.Where(con=>con.IsDeleted==false).FirstOrDefault(),
                SkillsTeacherDetails=_db.SkillsTeacherDetails.Where(s=>s.IsDeleted==false).ToList()

            };

            return View(teacherDetailsVM);
        }
        
    }
}
