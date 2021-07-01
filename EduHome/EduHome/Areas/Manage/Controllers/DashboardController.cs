using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.Controllers
{
        [Area("Manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class DashboardController : Controller
    {
        [Authorize(Roles ="Admin,SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
