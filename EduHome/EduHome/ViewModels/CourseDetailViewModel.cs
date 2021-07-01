using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourseDetailViewModel
    {
        public List<Tag> Tags { get; set; }
        public Course Course { get; set; }
        public List<Category> Categories { get; set; }
        public List<Request> Requests { get; set; }
    }
}
