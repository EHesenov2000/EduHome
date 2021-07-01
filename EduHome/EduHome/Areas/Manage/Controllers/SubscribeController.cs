using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;
        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Subscribers.Count() / 4m);
            List<Subscribe> subscribes = _context.Subscribers.Skip((page - 1) * 4).Take(4).ToList();

            return View(subscribes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subscribe subscribe)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "sehvlik oldu");
                return View();
            }
            _context.Subscribers.Add(subscribe);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            if (_context.Subscribers.FirstOrDefault(x => x.Id == id) == null)
            {
                return RedirectToAction("index");
            }
            _context.Subscribers.Remove(_context.Subscribers.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Subscribe subscribe = _context.Subscribers.FirstOrDefault(x => x.Id == id);
            if (subscribe == null)
            {
                return RedirectToAction("index");
            }

            return View(subscribe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Subscribe subscribe)
        {
            if (!ModelState.IsValid) return View();

            Subscribe existSubscribe = _context.Subscribers.FirstOrDefault(x => x.Id == id);

            if (existSubscribe == null)
            {
                return RedirectToAction("index");
            }

            existSubscribe.Email = subscribe.Email;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
