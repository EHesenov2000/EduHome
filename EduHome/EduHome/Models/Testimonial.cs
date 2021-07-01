using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100, ErrorMessage = "max uzunluq 100")]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [StringLength(maximumLength:200, ErrorMessage = "max uzunluq 200")]
        public string Text { get; set; }
        [StringLength(maximumLength:30, ErrorMessage = "max uzunluq 30")]
        public string FullName { get; set; }
        [StringLength(maximumLength:20, ErrorMessage = "max uzunluq 20")]
        public string Position { get; set; }
    }
}
