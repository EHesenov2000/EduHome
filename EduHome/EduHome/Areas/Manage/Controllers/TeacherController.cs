using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Teachers.Count() / 4m);
            List<Teacher> teachers = _context.Teachers.Include(x => x.EventTeachers).ThenInclude(x => x.Event).Include(x => x.Skills).Include(x => x.Courses).Skip((page - 1) * 4).Take(4).ToList();

            return View(teachers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (teacher.ImageFile != null)
            {
                if (teacher.ImageFile.ContentType != "image/png" && teacher.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (teacher.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + teacher.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/teacher", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    teacher.ImageFile.CopyTo(stream);
                }
                teacher.Image = fileName;
            }

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Teacher teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return RedirectToAction("index");
            }
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/teacher", teacher.Image);
            System.IO.File.Delete(path);

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Teacher teacher = _context.Teachers.Include(x=>x.Skills).FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return RedirectToAction("index");
            }

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Teacher teacher)
        {

            Teacher existTeacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (existTeacher == null)
            {
                return RedirectToAction("index");
            }
            if (teacher.ImageFile != null)
            {
                if (teacher.ImageFile.ContentType != "image/png" && teacher.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (teacher.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + teacher.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/teacher", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    teacher.ImageFile.CopyTo(stream);
                }
                if (existTeacher.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/teacher", existTeacher.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existTeacher.Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            List<Skill> existSkills = _context.Skills.Where(x=>x.TeacherId==teacher.Id).ToList();


            List<Skill> skills = teacher.Skills;
            if (skills != null)
            {
                _context.Teachers.FirstOrDefault(x => x.Id == teacher.Id).Skills=skills;
            }
            if (existSkills!=null)
            {
                _context.Skills.RemoveRange(existSkills);
            }


            existTeacher.Position = teacher.Position;
            existTeacher.FullName = teacher.FullName;
            existTeacher.FacebookUrl = teacher.FacebookUrl;
            existTeacher.PinterestUrl = teacher.PinterestUrl;
            existTeacher.VimeUrl = teacher.VimeUrl;
            existTeacher.TwitterUrl = teacher.TwitterUrl;
            existTeacher.About = teacher.About;
            existTeacher.Degree = teacher.Degree;
            existTeacher.Experience = teacher.Experience;
            existTeacher.Hobbies = teacher.Hobbies;
            existTeacher.Email = teacher.Email;
            existTeacher.Faculty = teacher.Faculty;
            existTeacher.PhoneNumber = teacher.PhoneNumber;
            existTeacher.SkypeName = teacher.SkypeName;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
