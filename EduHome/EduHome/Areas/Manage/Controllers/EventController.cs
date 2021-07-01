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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Events.Count() / 4m);
            List<Event> events = _context.Events.Include(x => x.EventTeachers).ThenInclude(x => x.Teacher).Include(x => x.EventTags).ThenInclude(x => x.Tag).Skip((page - 1) * 4).Take(4).ToList();

            return View(events);
        }
        public IActionResult Create()
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event newEvent)
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();


            if (!ModelState.IsValid)
            {
                return View();
            }
            if (newEvent.ImageFile != null)
            {
                if (newEvent.ImageFile.ContentType != "image/png" && newEvent.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (newEvent.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + newEvent.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/event", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    newEvent.ImageFile.CopyTo(stream);
                }
                newEvent.Image = fileName;
            }

            if (newEvent.TagIds != null)
            {
                foreach (var tagId in newEvent.TagIds)
                {
                    EventTags eventTag = new EventTags
                    {
                        Event = newEvent,
                        TagId = tagId
                    };
                    _context.EventTags.Add(eventTag);
                }
            }

            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Event newEvent = _context.Events.FirstOrDefault(x => x.Id == id);
            if (newEvent == null)
            {
                return RedirectToAction("index");
            }
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/event", newEvent.Image);
            System.IO.File.Delete(path);

            _context.Events.Remove(newEvent);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            Event newEvent = _context.Events.Include(x=>x.EventTags).Include(x=>x.EventTeachers).FirstOrDefault(x => x.Id == id);
            if (newEvent == null)
            {
                return RedirectToAction("index");
            }

            return View(newEvent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event newEvent)
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            Event existEvent = _context.Events.FirstOrDefault(x => x.Id == id);
            if (existEvent == null)
            {
                return RedirectToAction("index");
            }
            if (newEvent.ImageFile != null)
            {
                if (newEvent.ImageFile.ContentType != "image/png" && newEvent.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (newEvent.ImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + newEvent.ImageFile.FileName;
                var path = Path.Combine(rootPath, "uploads/event", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    newEvent.ImageFile.CopyTo(stream);
                }
                if (existEvent.Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/event", existEvent.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existEvent.Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }



            var existTags = _context.EventTags.Where(x => x.EventId == id).ToList();
            if (newEvent.TagIds != null)
            {
                foreach (var tagId in newEvent.TagIds)
                {
                    var existTag = existTags.FirstOrDefault(x => x.TagId == tagId);
                    if (existTag == null)
                    {
                        EventTags eventTag = new EventTags
                        {
                            EventId = id,
                            TagId = tagId
                        };
                        _context.EventTags.Add(eventTag);
                    }
                    else
                    {
                        existTags.Remove(existTag);
                    }
                }

            }

            _context.EventTags.RemoveRange(existTags);

            var existTeachers = _context.EventTeachers.Where(x => x.EventId == id).ToList();
            if (newEvent.TeacherIds != null)
            {
                foreach (var eventId in newEvent.TeacherIds)
                {
                    var existTeacher = existTeachers.FirstOrDefault(x => x.TeacherId == eventId);
                    if (existTeacher == null)
                    {
                        EventTags eventTeacher = new EventTags
                        {
                            EventId = id,
                            TagId = eventId
                        };
                        _context.EventTags.Add(eventTeacher);
                    }
                    else
                    {
                        existTeachers.Remove(existTeacher);
                    }
                }

            }

            _context.EventTeachers.RemoveRange(existTeachers);


            existEvent.Name = newEvent.Name;
            existEvent.StartTime = newEvent.StartTime;
            existEvent.EndTime = newEvent.EndTime;
            existEvent.City = newEvent.City;
            existEvent.About = newEvent.About;
            existEvent.CreatedAt = newEvent.CreatedAt;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
