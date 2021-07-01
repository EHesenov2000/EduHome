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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Sliders.Count() / 4m);
            List<Slider> sliders = _context.Sliders.Skip((page - 1) * 4).Take(4).ToList();

            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slider.BackgroundFile!=null)
            {
                if (slider.BackgroundFile.ContentType != "image/png" && slider.BackgroundFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("BackgroundFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (slider.BackgroundFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("BackgroundFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + slider.BackgroundFile.FileName;
                var path = Path.Combine(rootPath, "uploads/slider", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.BackgroundFile.CopyTo(stream);
                }
                slider.BackgroundImage = fileName;
            }
            if (slider.OverFile != null)
            {
                if (slider.OverFile.ContentType != "image/png" && slider.OverFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("OverFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (slider.OverFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("OverFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + slider.OverFile.FileName;
                var path = Path.Combine(rootPath, "uploads/slider", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.OverFile.CopyTo(stream);
                }
                slider.OverImage = fileName;
            }
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null)
            {
                return RedirectToAction("index");
            }
            if (_context.Sliders.Count()==2)
            {
                return RedirectToAction("index");
            }



;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/slider", slider.OverImage);
            System.IO.File.Delete(path);



            string rootPath1 = _env.WebRootPath;
            var path1 = Path.Combine(rootPath, "uploads/slider", slider.BackgroundImage);
            System.IO.File.Delete(path1);


            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider==null)
            {
                return RedirectToAction("index");
            }

            return View(slider);
        }
        [HttpPost]
        public IActionResult Edit(int id,Slider slider)
        {
            Slider existSlider = _context.Sliders.FirstOrDefault(x=>x.Id==id);
            if (existSlider==null)
            {
                return RedirectToAction("index");
            }
            if (slider.BackgroundFile!=null)
            {
                if (slider.BackgroundFile.ContentType != "image/png" && slider.BackgroundFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("BackgroundFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (slider.BackgroundFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("BackgroundFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + slider.BackgroundFile.FileName;
                var path = Path.Combine(rootPath, "uploads/slider", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.BackgroundFile.CopyTo(stream);
                }
                if (existSlider.BackgroundImage != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/slider", existSlider.BackgroundImage);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existSlider.BackgroundImage = fileName;
            }

            if (slider.OverFile != null)
            {
                if (slider.OverFile.ContentType != "image/png" && slider.OverFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("OverFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (slider.OverFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("OverFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + slider.OverFile.FileName;
                var path = Path.Combine(rootPath, "uploads/slider", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.OverFile.CopyTo(stream);
                }
                if (existSlider.OverImage != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/slider", existSlider.OverImage);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existSlider.OverImage = fileName;
            }


            if (!ModelState.IsValid)
            {
                return View();
            }




            existSlider.Title = slider.Title;
            existSlider.Context = slider.Context;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
