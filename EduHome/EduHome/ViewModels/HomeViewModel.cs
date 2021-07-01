using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeViewModel
    {
        public AboutEduHome AboutEduHomeForHomePage { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Event> Events { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Setting> Settings { get; set; }
        public List<NoticeBoardItem> NoticeBoardItems { get; set; }
    }

}
