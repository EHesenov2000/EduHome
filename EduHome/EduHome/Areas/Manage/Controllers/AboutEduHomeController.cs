using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AboutEduHomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutEduHomeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.AboutEduHomes.Count() / 4m);
            List<AboutEduHome> aboutEduHomes = _context.AboutEduHomes.Skip((page - 1) * 4).Take(4).ToList();

            return View(aboutEduHomes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AboutEduHome aboutEduHome)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.AboutEduHomes.Count() == 2)
            {
                if (_context.AboutEduHomes.Any(x => x.IsHome) && _context.AboutEduHomes.Any(x => !x.IsHome))
                {
                    ModelState.AddModelError("","Siz artiq her 2 sehife ucun data yaratmisiz elave yarada bilmezsiniz, zehmet olmasa yaratdiginizi deyisesiniz");
                    return View();

                }
            }
            if (aboutEduHome.ImageFile != null)
            {
                if (aboutEduHome.ImageFile.ContentType != "image/png" && aboutEduHome.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (aboutEduHome.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + aboutEduHome.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/aboutEduHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    aboutEduHome.ImageFile.CopyTo(stream);
                }
                aboutEduHome.Image = fileName;
            }
            _context.AboutEduHomes.Add(aboutEduHome);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            AboutEduHome aboutEduHome = _context.AboutEduHomes.FirstOrDefault(x => x.Id == id);
            if (aboutEduHome == null)
            {
                return RedirectToAction("index");
            }
            if (_context.AboutEduHomes.Count() == 2 )
            {
                if (_context.AboutEduHomes.Any(x=>x.IsHome) && _context.AboutEduHomes.Any(x => !x.IsHome))
                {
                    return RedirectToAction("index");

                }
            }

;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/aboutEduHome", aboutEduHome.Image);
            System.IO.File.Delete(path);


            _context.AboutEduHomes.Remove(aboutEduHome);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            AboutEduHome aboutEduHome = _context.AboutEduHomes.FirstOrDefault(x => x.Id == id);
            if (aboutEduHome == null)
            {
                return RedirectToAction("index");
            }

            return View(aboutEduHome);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AboutEduHome aboutEduHome)
        {
            AboutEduHome existaboutEduHome = _context.AboutEduHomes.FirstOrDefault(x => x.Id == id);
            if (existaboutEduHome == null)
            {
                return RedirectToAction("index");
            }
            if (aboutEduHome.ImageFile != null)
            {
                if (aboutEduHome.ImageFile.ContentType != "image/png" && aboutEduHome.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (aboutEduHome.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + aboutEduHome.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/aboutEduHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    aboutEduHome.ImageFile.CopyTo(stream);
                }
                if (existaboutEduHome.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/aboutEduHome", existaboutEduHome.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existaboutEduHome.Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }


            existaboutEduHome.Title = aboutEduHome.Title;
            existaboutEduHome.Text = aboutEduHome.Text;
            existaboutEduHome.IsHome = aboutEduHome.IsHome;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
