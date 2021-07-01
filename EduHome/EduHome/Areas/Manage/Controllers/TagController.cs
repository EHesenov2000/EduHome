using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Tags.Count() / 4m);
            List<Tag> tags = _context.Tags.Include(x => x.CourseTags).Include(x=>x.EventTags).Skip((page - 1) * 4).Take(4).ToList();

            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.Tags.Any(x => x.Name.ToLower() == tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "This tag already created");
                return View();
            }

            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (tag == null)
            {
                return RedirectToAction("index");
            }
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (tag == null)
            {
                return RedirectToAction("index");
            }

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tag tag)
        {
            if (!ModelState.IsValid) return View();

            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (existTag == null)
            {
                return RedirectToAction("index");
            }
            if (_context.Tags.Any(x => x.Id != id && x.Name.ToLower() == tag.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "This tag already created");
                return View();
            }


            existTag.Name = tag.Name;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}
