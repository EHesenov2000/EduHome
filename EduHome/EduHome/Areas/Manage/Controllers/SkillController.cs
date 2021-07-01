//using EduHome.DAL;
//using EduHome.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EduHome.Areas.Manage.Controllers
//{
//    [Area("manage")]
//    [Authorize(Roles = "Admin,SuperAdmin")]
//    public class SkillController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _env;

//        public SkillController(AppDbContext context, IWebHostEnvironment env)
//        {
//            _context = context;
//            _env = env;
//        }
//        public IActionResult Index(int page = 1)
//        {
//            ViewBag.SelectedPage = page;
//            ViewBag.TotalPageCount = Math.Ceiling(_context.Skills.Count() / 4m);
//            List<Skill> skills = _context.Skills.Skip((page - 1) * 4).Take(4).ToList();

//            return View(skills);
//        }
//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Skill skill)
//        {
//            if (!ModelState.IsValid)
//            {
//                ModelState.AddModelError("", "sehvlik oldu");
//                return View();
//            }
//            _context.Skills.Add(skill);
//            _context.SaveChanges();

//            return RedirectToAction("index");
//        }
//        public IActionResult Delete(int id)
//        {
//            if (_context.Skills.FirstOrDefault(x => x.Id == id) == null)
//            {
//                return RedirectToAction("index");
//            }
//            _context.Skills.Remove(_context.Skills.FirstOrDefault(x => x.Id == id));
//            _context.SaveChanges();
//            return RedirectToAction("index");
//        }
//        public IActionResult Edit(int id)
//        {
//            Skill skill = _context.Skills.FirstOrDefault(x => x.Id == id);
//            if (skill == null)
//            {
//                return RedirectToAction("index");
//            }

//            return View(skill);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id,Skill skill)
//        {
//            if (!ModelState.IsValid) return View();
//            if (!(skill.Percent>=0 && skill.Percent<=100))
//            {
//                ModelState.AddModelError("Percent", "Percent deyeri 0-100 arasi olmalidir");
//                return View();
//            }

//            Skill existSkill = _context.Skills.FirstOrDefault(x => x.Id == id);

//            if (existSkill == null)
//            {
//                return RedirectToAction("index");
//            }
//            existSkill.Name = skill.Name;
//            existSkill.Percent = skill.Percent;

//            _context.SaveChanges();

//            return RedirectToAction("index");
//        }
//    }
//}
