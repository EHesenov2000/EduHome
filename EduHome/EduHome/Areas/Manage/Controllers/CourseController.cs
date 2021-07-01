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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Courses.Count() / 4m);
            List<Course> courses = _context.Courses.Include(x=>x.Category).Include(x=>x.Teacher).Include(x=>x.Features).Include(x=>x.CourseTags).ThenInclude(x=>x.Tag).Skip((page - 1) * 4).Take(4).ToList();

            return View(courses);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (!_context.Categories.Any(x => x.Id == course.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Xetaniz var!");
            }
            if (!_context.Teachers.Any(x => x.Id == course.TeacherId))
            {
                ModelState.AddModelError("TeacherId", "Xetaniz var!");
            }


            if (!ModelState.IsValid)
            {
                return View();
            }
            if (course.ImageFile != null)
            {
                if (course.ImageFile.ContentType != "image/png" && course.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (course.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + course.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/course", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    course.ImageFile.CopyTo(stream);
                }
                course.Image = fileName;
            }



            if (course.TagIds != null)
            {
                foreach (var tagId in course.TagIds)
                {
                    CourseTags courseTag = new CourseTags
                    {
                        Course = course,
                        TagId = tagId
                    };
                    _context.CourseTags.Add(courseTag);
                }
            }
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Course course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                return RedirectToAction("index");
            }
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/course", course.Image);
            System.IO.File.Delete(path);

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            Course course = _context.Courses.Include(x=>x.CourseTags).Include(x=>x.Features).FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                return RedirectToAction("index");
            }

            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            Course existCourse = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (!_context.Categories.Any(x => x.Id == course.CategoryId)) return RedirectToAction("index");
            if (!_context.Teachers.Any(x => x.Id == course.TeacherId)) return RedirectToAction("index");
            if (existCourse == null)
            {
                return RedirectToAction("index");
            }
            if (course.ImageFile != null)
            {
                if (course.ImageFile.ContentType != "image/png" && course.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (course.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + course.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/course", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    course.ImageFile.CopyTo(stream);
                }
                if (existCourse.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/course", existCourse.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existCourse.Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var existTags = _context.CourseTags.Where(x => x.CourseId == id).ToList();
            if (course.TagIds != null)
            {
                foreach (var tagId in course.TagIds)
                {
                    var existTag = existTags.FirstOrDefault(x => x.TagId == tagId);
                    if (existTag == null)
                    {
                        CourseTags bookTag = new CourseTags
                        {
                            CourseId = id,
                            TagId = tagId
                        };
                        _context.CourseTags.Add(bookTag);
                    }
                    else
                    {
                        existTags.Remove(existTag);
                    }
                }

            }
            _context.CourseTags.RemoveRange(existTags);

            List<Feature> existFeatures= _context.Features.Where(x => x.CourseId == course.Id).ToList();


            List<Feature> features = course.Features;
            if (features != null)
            {
                _context.Courses.FirstOrDefault(x => x.Id == course.Id).Features = features;
            }
            if (existFeatures != null)
            {
                _context.Features.RemoveRange(existFeatures);
            }

            existCourse.Context = course.Context;
            existCourse.About = course.About;
            existCourse.HowToApply = course.HowToApply;
            existCourse.Certification = course.Certification;
            existCourse.Price = course.Price;
            existCourse.CategoryId = course.CategoryId;
            existCourse.TeacherId = course.TeacherId;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
