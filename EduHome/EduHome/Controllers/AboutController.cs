using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
     
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                aboutEduHome = _context.AboutEduHomes.FirstOrDefault(x => !x.IsHome),
                Teachers = _context.Teachers.Take(4).ToList(),
                Testimonials = _context.Testimonials.ToList(),
                Settings = _context.Settings.ToList(),
                NoticeBoardItems=_context.NoticeBoardItems.ToList(),
            };
            return View(aboutViewModel);
        }

    }
}
