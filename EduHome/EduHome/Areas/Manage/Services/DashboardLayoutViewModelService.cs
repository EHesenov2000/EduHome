using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EduHome.Areas.Manage.Services
{
    public class DashboardLayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public DashboardLayoutViewModelService(AppDbContext context, IHttpContextAccessor contextAccessor, RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Authorize(Roles ="Admin,SuperAdmin")]
        public List<AppUser> GetFullName()
        {
            return _context.Users.Where(x => x.IsAdmin).ToList();
        }

        public async Task<string> GetUserRole(AppUser user)
        {
            string name = (await _userManager.GetRolesAsync(user))[0];
            return name;
                
        }
    }
}
