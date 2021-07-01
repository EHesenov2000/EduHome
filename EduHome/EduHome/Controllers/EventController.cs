using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search,int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Events.Count() / 6m);
            List<Event> events = _context.Events.Skip((page - 1) * 6).Take(6).ToList();
            return View(events);
        }
        public IActionResult Detail(int id)
        {
            EventDetailViewModel eventDetail = new EventDetailViewModel()
            {
                Event = _context.Events.Include(x=>x.EventTeachers).ThenInclude(x=>x.Teacher).Include(x=>x.EventTags).ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == id),
                Tags = _context.Tags.ToList(),
                Categories = _context.Categories.Include(x=>x.Courses).ToList(),
            };
            return View(eventDetail);
        }
        public IActionResult EventPartial(string search)
        {
            List<Event> events = _context.Events.Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Name.ToLower().Contains(search.ToLower()))).ToList();
            return PartialView(events);
        }
    }
}
