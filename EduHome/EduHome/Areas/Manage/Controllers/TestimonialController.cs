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
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Testimonials.Count() / 4m);
            List<Testimonial> testimonials = _context.Testimonials.Skip((page - 1) * 4).Take(4).ToList();

            return View(testimonials);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (testimonial.ImageFile != null)
            {
                if (testimonial.ImageFile.ContentType != "image/png" && testimonial.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (testimonial.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + testimonial.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/testimonial", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    testimonial.ImageFile.CopyTo(stream);
                }
                testimonial.Image = fileName;
            }
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null)
            {
                return RedirectToAction("index");
            }
            if (_context.Testimonials.Count() == 2)
            {
                return RedirectToAction("index");
            }

;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/testimonial", testimonial.Image);
            System.IO.File.Delete(path);


            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null)
            {
                return RedirectToAction("index");
            }

            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Testimonial testimonial)
        {
            Testimonial existTestimonial= _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (existTestimonial == null)
            {
                return RedirectToAction("index");
            }
            if (testimonial.ImageFile != null)
            {
                if (testimonial.ImageFile.ContentType != "image/png" && testimonial.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (testimonial.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + testimonial.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/testimonial", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    testimonial.ImageFile.CopyTo(stream);
                }
                if (existTestimonial.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/testimonial", existTestimonial.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existTestimonial.Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }


            existTestimonial.Text = testimonial.Text;
            existTestimonial.FullName = testimonial.FullName;
            existTestimonial.Position = testimonial.Position;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
