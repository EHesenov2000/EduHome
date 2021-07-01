using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Contacts.Count() / 4m);
            List<Contact> contacts = _context.Contacts.Skip((page - 1) * 4).Take(4).ToList();

            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "sehvlik oldu");
                return View();
            }
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            if (_context.Contacts.FirstOrDefault(x => x.Id == id) == null)
            {
                return RedirectToAction("index");
            }
            _context.Contacts.Remove(_context.Contacts.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return RedirectToAction("index");
            }

            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Contact contact)
        {
            if (!ModelState.IsValid) return View();

            Contact existContact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (existContact == null)
            {
                return RedirectToAction("index");
            }
            existContact.Name = contact.Name;
            existContact.Email = contact.Email;
            existContact.Subject = contact.Subject;
            existContact.Message = contact.Message;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
