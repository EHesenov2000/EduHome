using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [StringLength(maximumLength:30)]
        public string Position { get; set; }
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        [StringLength(maximumLength:100)]
        public string FacebookUrl { get; set; }
        [StringLength(maximumLength:100)]
        public string PinterestUrl { get; set; }
        [StringLength(maximumLength:100)]
        public string VimeUrl { get; set; }
        [StringLength(maximumLength:100)]
        public string TwitterUrl { get; set; }
        [StringLength(maximumLength:300)]
        public string About { get; set; }
        [StringLength(maximumLength:50)]
        public string Degree { get; set; }
        [StringLength(maximumLength:100)]
        public string Experience { get; set; }
        [StringLength(maximumLength:100)]
        public string Hobbies { get; set; }
        [StringLength(maximumLength:50)]
        public string Faculty { get; set; }
        [StringLength(maximumLength: 30)]
        public string Email { get; set; }
        [StringLength(maximumLength: 20)]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 30)]
        public string SkypeName { get; set; }
        public List<EventTeachers> EventTeachers { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Course> Courses { get; set; }

    }
}
