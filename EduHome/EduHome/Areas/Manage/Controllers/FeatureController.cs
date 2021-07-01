//using EduHome.DAL;
//using EduHome.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EduHome.Areas.Manage.Controllers
//{
//    [Area("manage")]
//    [Authorize(Roles = "Admin,SuperAdmin")]
//    public class FeatureController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _env;

//        public FeatureController(AppDbContext context, IWebHostEnvironment env)
//        {
//            _context = context;
//            _env = env;
//        }
//        //public IActionResult Index(int page = 1)
//        //{
//        //    ViewBag.SelectedPage = page;
//        //    ViewBag.TotalPageCount = Math.Ceiling(_context.Features.Count() / 5m);
//        //    List<Feature> features = _context.Features.Include(x=>x.Course).ThenInclude(x=>x.Category).Skip((page-1)*5).Take(5).ToList();
//        //    return View(features);
//        //}
//        //public IActionResult Create()
//        //{
//        //    return View();
//        //}
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public IActionResult Create(Feature feature)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        ModelState.AddModelError("","sehvlik oldu");
//        //        return View();
//        //    }
//        //    _context.Features.Add(feature);
//        //    _context.SaveChanges();

//        //    return RedirectToAction("index");
//        //}
//        //public IActionResult Delete(int id)
//        //{
//        //    if (_context.Features.FirstOrDefault(x => x.Id == id) == null)
//        //    {
//        //        return RedirectToAction("index");
//        //    }
//        //    _context.Features.Remove(_context.Features.FirstOrDefault(x => x.Id == id));
//        //    _context.SaveChanges();
//        //    return RedirectToAction("index");
//        //}
//        //public IActionResult Edit(int id)
//        //{
//        //    Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
//        //    if (feature == null)
//        //    {
//        //        return RedirectToAction("index");
//        //    }

//        //    return View(feature);
//        //}
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public IActionResult Edit(int id, Feature feature)
//        //{
//        //    if (!ModelState.IsValid) return View();

//        //    Feature existFeature= _context.Features.FirstOrDefault(x => x.Id == id);

//        //    if (existFeature == null)
//        //    {
//        //        return RedirectToAction("index");
//        //    }
//        //    existFeature.StartDate = feature.StartDate;
//        //    existFeature.CourseDuration = feature.CourseDuration;
//        //    existFeature.ClassDuration = feature.ClassDuration;
//        //    existFeature.SkillLevel = feature.SkillLevel;
//        //    existFeature.Language = feature.Language;
//        //    existFeature.StudentsCount = feature.StudentsCount;
//        //    existFeature.Assesment = feature.Assesment;

//        //    _context.SaveChanges();

//        //    return RedirectToAction("index");
//        //}
//    }
//}
