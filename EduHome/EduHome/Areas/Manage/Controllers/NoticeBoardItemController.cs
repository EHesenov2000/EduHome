using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class NoticeBoardItemController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public NoticeBoardItemController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.NoticeBoardItems.Count() / 4m);
            List<NoticeBoardItem> noticeBoardItems = _context.NoticeBoardItems.Skip((page - 1) * 4).Take(4).ToList();

            return View(noticeBoardItems);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoticeBoardItem noticeBoardItem)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "sehvlik oldu");
                return View();
            }
            noticeBoardItem.CreatedAt = DateTime.UtcNow;
            _context.NoticeBoardItems.Add(noticeBoardItem);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete (int id)
        {
            if (_context.NoticeBoardItems.FirstOrDefault(x => x.Id == id) == null)
            {
                return RedirectToAction("index");
            }
            _context.NoticeBoardItems.Remove(_context.NoticeBoardItems.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            NoticeBoardItem noticeBoardItem = _context.NoticeBoardItems.FirstOrDefault(x => x.Id == id);
            if (noticeBoardItem == null)
            {
                return RedirectToAction("index");
            }

            return View(noticeBoardItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,NoticeBoardItem noticeBoardItem)
        {
            if (!ModelState.IsValid) return View();

            NoticeBoardItem existNoticeBoardItem = _context.NoticeBoardItems.FirstOrDefault(x => x.Id == id);

            if (existNoticeBoardItem == null)
            {
                return RedirectToAction("index");
            }
            existNoticeBoardItem.CreatedAt = noticeBoardItem.CreatedAt;
            existNoticeBoardItem.Text = noticeBoardItem.Text;
            existNoticeBoardItem.CreatedAt = DateTime.UtcNow;


            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
