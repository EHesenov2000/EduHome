using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Title { get; set; }
        [StringLength(maximumLength:300)]
        public string Context { get; set; }
        [StringLength(maximumLength:100)]
        public string BackgroundImage { get; set; }
        [StringLength(maximumLength:100)]
        public string OverImage { get; set; }

        [NotMapped]
        public IFormFile BackgroundFile { get; set; }
        [NotMapped]
        public IFormFile OverFile { get; set; }
    }
}
