using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        public List<EventTags> EventTags { get; set; }
        public List<CourseTags> CourseTags { get; set; }
    }
}
