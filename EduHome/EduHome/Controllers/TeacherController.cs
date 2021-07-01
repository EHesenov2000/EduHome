using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Teachers.Count() / 8m);
            List<Teacher> teachers = new List<Teacher>();
            teachers = _context.Teachers.Include(x=>x.Skills).Skip((page - 1) * 8).Take(8).ToList();
            return View(teachers);
        }
        public IActionResult Detail(int id)
        {
            Teacher teacher= _context.Teachers.Include(x=>x.Skills).FirstOrDefault(x => x.Id == id);
            return View(teacher);
        }
    }
}
