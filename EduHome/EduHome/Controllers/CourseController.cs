using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? categoryId,string search, int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.Search = search;
            int totalCount;
            decimal totalPage;

            List<Course> courses = new List<Course>();
            if (categoryId == null)
            {

                courses = _context.Courses.Include(x => x.Category).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Category.Name.ToLower().Contains(search.ToLower())))
                .Skip((page - 1) * 6).Take(6).ToList();
                totalCount = _context.Courses.Include(x => x.Category).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Category.Name.ToLower().Contains(search.ToLower()))).Count();
            }
            else
            {
                ViewBag.SelectedCategoryId = categoryId;
                courses = _context.Courses.Include(x => x.Category).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Category.Name.ToLower().Contains(search.ToLower())))
                .Where(x=>x.CategoryId==categoryId).Skip((page - 1) * 6).Take(6).ToList();
                totalCount = _context.Courses.Include(x => x.Category).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.Category.Name.ToLower().Contains(search.ToLower())))
                .Where(x => x.CategoryId == categoryId).Count();
            }
            totalPage = Math.Ceiling(totalCount / 6m);
            ViewBag.TotalPageCount = totalPage;

                
            return View(courses);


        }
        public IActionResult Detail(int id)
        {

            AppUser user = _context.Users.Include(x=>x.Requests).ThenInclude(x=>x.Course).FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (user.Requests.Where(x => x.CourseId == id)!=null)
            {
                foreach (var item in user.Requests.Where(x => x.CourseId == id).ToList())
                {
                    if (item.RequestDate.AddMonths(6)<DateTime.UtcNow)
                    {
                        _context.Requests.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            CourseDetailViewModel courseDetail = new CourseDetailViewModel()
            {
                Course = _context.Courses.Include(x => x.Category).Include(x=>x.Features).Include(x => x.CourseComments).ThenInclude(x => x.AppUser).Include(x => x.Features).Include(x => x.Teacher).Include(x => x.CourseTags).ThenInclude(x => x.Tag).FirstOrDefault(x => x.Id == id),
                Tags = _context.Tags.ToList(),
                Categories = _context.Categories.Include(x=>x.Courses).ToList(),
                Requests = _context.Requests.Include(x=>x.Course).Include(x => x.Course).ThenInclude(x => x.Features).Include(x => x.AppUser).ToList(),
            };
            return View(courseDetail);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(CourseComment comment)
        {
            if (!ModelState.IsValid) return RedirectToAction("index");

            Course course = _context.Courses.Include(x => x.CourseComments).FirstOrDefault(x => x.Id == comment.CourseId);

            if (course == null) return RedirectToAction("index");

            var user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            comment.AppUserId = user.Id;

            if (_context.CourseComments.Any(x => x.CourseId == comment.CourseId && x.AppUserId == user.Id))
            {
                return RedirectToAction("index");
            }

            double commentCount = course.CourseComments.Count() + 1;
            comment.CreatedAt = DateTime.UtcNow;
            _context.CourseComments.Add(comment);

            _context.SaveChanges();

            return RedirectToAction("detail", new { id = comment.CourseId });
        }
        [Authorize(Roles = "Member")]
        public IActionResult LoadComment(int id, int page = 1)
        {
            List<CourseComment> comments = _context.CourseComments.Include(x => x.AppUser).Where(x => x.CourseId == id).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 2).Take(2).ToList();

            return PartialView("_CourseComments", comments);
        }

        [Authorize(Roles ="Member")]
        public IActionResult RequestCourse(int id)
        {
            ViewBag.CourseId = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RequestCourse(int courseId,Request request)
        {
      
            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = _context.Users.Include(x=>x.Requests).ThenInclude(x=>x.Course).FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }
            else
            {
                return View(); 
            }
            if (_context.Users.Include(x=>x.Requests).FirstOrDefault(x=>x.Id==user.Id).Requests.Any(x=>x.CourseId==courseId) && _context.Users.Include(x => x.Requests).FirstOrDefault(x => x.Id == user.Id).Requests.FirstOrDefault(x=>x.CourseId==courseId).Status!=Enums.RequestStatus.UserReject)
            {
                return RedirectToAction("index");
            }
            //if (_context.Requests.Any(x=>x.CourseId==id))
            //{
            //    ModelState.AddModelError("", "Artiq bu kurs ucun request gondermisiz.");
            //    return View("RequestCourse");
            //}
            //if (user.Requests.FirstOrDefault(x => x.CourseId == courseId).Status.ToString() == "AdminReject" && user.Requests.FirstOrDefault(x => x.CourseId == courseId).RequestDate.AddMonths(6) < DateTime.UtcNow)
            //{
            //    _context.Requests.Remove(_context.Requests.FirstOrDefault(x => x.CourseId == courseId && x.AppUserId == user.Id ));
            //}
            request.AppUserId = user.Id;
            request.CourseId = courseId;
            request.UserName = user.FullName;
            request.RequestDate = DateTime.UtcNow;
            request.Status = Enums.RequestStatus.Pending;
            request.Id = 0;
            request.TotalPrice = _context.Courses.FirstOrDefault(x => x.Id == courseId).Price;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Melumatlarda yanlisliq tapildi");
                return View();
            }
            _context.Requests.Add(request);

            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public string GetStatus(int id)
        {
            return _context.Requests.FirstOrDefault(x => x.CourseId == id).Status.ToString() ;
        }

        [Authorize(Roles = "Member")]
        public IActionResult GetCourses(string userId)
        {
            List<Request> requests = _context.Requests.Include(x => x.AppUser).Include(x => x.Course).ThenInclude(x => x.Category).Where(x => x.AppUserId == userId).ToList();
            if (requests==null)
            {
                return RedirectToAction("detail");
            }
            return View(requests);
        }

        [Authorize(Roles = "Member")]
        public IActionResult RejectCourse(int courseId, string userId)
        {
            if (_context.Requests.FirstOrDefault(x => x.CourseId == courseId && x.AppUserId == userId) != null)
            {
                DateTime date = _context.Requests.Where(x => x.CourseId == courseId && x.AppUserId == userId).ToList().Max(x => x.RequestDate);
                _context.Requests.FirstOrDefault(x => x.CourseId == courseId && x.AppUserId == userId && x.RequestDate == date).Status = Enums.RequestStatus.UserReject;

            }
            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
