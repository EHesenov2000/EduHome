using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseTags
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
