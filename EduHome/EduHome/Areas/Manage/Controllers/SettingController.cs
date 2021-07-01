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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Setting setting = _context.Settings.First();
            return View(setting);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Setting setting)
        {
            if (_context.Settings.Count() == 1)
            {
                ModelState.AddModelError("", "Yalniz 1 eded setting ola biler,yaratdiginiz settingi deyise bilersiz");
                return View();
            }

            if (setting.HeaderFile != null)
            {
                if (setting.HeaderFile.ContentType != "image/png" && setting.HeaderFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderFile", "Jpeg ve ya png formatinda data olmalidir.");
                    return View();
                }
                if (setting.HeaderFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HeaderFile", "File olcusu 2mb-dan cox olmaz!");
                    return View();
                }

                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.HeaderFile.FileName;
                var path = Path.Combine(rootPath, "uploads/setting", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.HeaderFile.CopyTo(stream);
                }
                setting.HeaderLogo = fileName;
            }

            if (setting.FooterFile != null)
            {
                if (setting.FooterFile.ContentType != "image/png" && setting.FooterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("FooterFile", "Jpeg ve ya png formatinda data olmalidir.");
                    return View();
                }
                if (setting.FooterFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("FooterFile", "File olcusu 2mb-dan cox olmaz!");
                    return View();
                }

                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.FooterFile.FileName;
                var path = Path.Combine(rootPath, "uploads/setting", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.FooterFile.CopyTo(stream);
                }
                setting.FooterLogo = fileName;
            }


            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Settings.Add(setting);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (setting == null)
            {
                return RedirectToAction("index");
            }




;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/setting", setting.HeaderLogo);
            System.IO.File.Delete(path);



            string rootPath1 = _env.WebRootPath;
            var path1 = Path.Combine(rootPath, "uploads/setting", setting.FooterLogo);
            System.IO.File.Delete(path1);

            if (_context.Settings.Count() == 1)
            {
                return RedirectToAction("index");
            }
            _context.Settings.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (setting == null)
            {
                return RedirectToAction("index");
            }

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (existSetting == null)
            {
                return RedirectToAction("index");
            }
            if (setting.HeaderFile != null)
            {
                if (setting.HeaderFile.ContentType != "image/png" && setting.HeaderFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (setting.HeaderFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HeaderFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.HeaderFile.FileName;
                var path = Path.Combine(rootPath, "uploads/setting", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.HeaderFile.CopyTo(stream);
                }
                if (existSetting.HeaderLogo != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/setting", existSetting.HeaderLogo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existSetting.HeaderLogo = fileName;
            }

            if (setting.FooterFile != null)
            {
                if (setting.FooterFile.ContentType != "image/png" && setting.FooterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("FooterFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (setting.FooterFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("FooterFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.FooterFile.FileName;
                var path = Path.Combine(rootPath, "uploads/setting", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.FooterFile.CopyTo(stream);
                }
                if (existSetting.FooterLogo != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/setting", existSetting.FooterLogo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existSetting.FooterLogo = fileName;
            }


            if (!ModelState.IsValid)
            {
                return View();
            }


            existSetting.QuestionNumber = setting.QuestionNumber;
            existSetting.FooterText = setting.FooterText;
            existSetting.FacebookUrl = setting.FacebookUrl;
            existSetting.PinterestUrl = setting.PinterestUrl;
            existSetting.VimeUrl = setting.VimeUrl;
            existSetting.TwitterUrl = setting.TwitterUrl;
            existSetting.Address = setting.Address;
            existSetting.PhoneNumber1 = setting.PhoneNumber1;
            existSetting.PhoneNumber2 = setting.PhoneNumber2;
            existSetting.Mail = setting.Mail;
            existSetting.WebSite = setting.WebSite;
            existSetting.Latitude = setting.Latitude;
            existSetting.Longitude = setting.Longitude;
            existSetting.VideoUrl = setting.VideoUrl;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
