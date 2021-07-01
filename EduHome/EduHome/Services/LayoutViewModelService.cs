using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public LayoutViewModelService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
        public Subscribe Take()
        {
            Subscribe subscribe = new Subscribe();
            return subscribe;
        }
    }
}
