using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel HomeVM = new HomeViewModel()
            {
                AboutEduHomeForHomePage = _context.AboutEduHomes.FirstOrDefault(x => x.IsHome),
                Sliders = _context.Sliders.ToList(),
                Testimonials = _context.Testimonials.ToList(),
                Events = _context.Events.Include(x => x.EventTags).Include(x => x.EventTeachers).ToList(),
                Courses = _context.Courses.Include(x => x.Category).ToList(),
                Settings = _context.Settings.ToList(),
                NoticeBoardItems = _context.NoticeBoardItems.ToList(),
            };
            return View(HomeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            if (_context.Subscribers.Any(x=>x.Email==subscribe.Email))
            {
                return RedirectToAction("index");
            }
            _context.Subscribers.Add(subscribe);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


    }
}
