using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event
    {
        public int Id { get; set; }
        [StringLength(maximumLength:150)]
        public string Name { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [StringLength(maximumLength:30)]
        public string City { get; set; }
        [StringLength(maximumLength:300)]
        public string About { get; set; }   
        public DateTime CreatedAt { get; set; }
        public List<EventTeachers> EventTeachers { get; set; }
        public List<EventTags> EventTags { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }
        [NotMapped]
        public List<int> TeacherIds { get; set; }
    }
}
