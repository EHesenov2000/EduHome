using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Categories.Count() / 5m);
            List<Category> categories = _context.Categories.Skip((page - 1) * 5).Take(5).ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "sehvlik oldu");
                return View();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            if (_context.Categories.FirstOrDefault(x => x.Id == id) == null)
            {
                return RedirectToAction("index");
            }
            _context.Categories.Remove(_context.Categories.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return RedirectToAction("index");
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (!ModelState.IsValid) return View();
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (existCategory == null)
            {
                return RedirectToAction("index");
            }
            if (_context.Categories.Any(x => x.Name == category.Name))
            {
                ModelState.AddModelError("", "This category name already exists in database");
                return View();
            }

            existCategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
