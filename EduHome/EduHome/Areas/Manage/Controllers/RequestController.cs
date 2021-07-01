using EduHome.DAL;
using EduHome.Enums;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class RequestController : Controller
    {
        private readonly AppDbContext _context;

        public RequestController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Requests.Count() / 5m);

            var model = _context.Requests.Include(x => x.AppUser).Include(x=>x.Course).ThenInclude(x=>x.Category).OrderByDescending(x => x.RequestDate).Skip((page - 1) * 5).Take(5).ToList();

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            Request request = _context.Requests.Include(x => x.Course).ThenInclude(x=>x.Category).Include(x=>x.AppUser).FirstOrDefault(x => x.Id == id);

            if (request == null)
            {
                return RedirectToAction("index");
            }

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, RequestStatus status)
        {
            Request request = _context.Requests.FirstOrDefault(x => x.Id == id);

            if (request == null)
            {
                return RedirectToAction("index");
            }

            request.Status = status;
            _context.SaveChanges();

            return RedirectToAction("index");
        }


    }
}
