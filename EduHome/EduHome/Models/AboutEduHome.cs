using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class AboutEduHome
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Title { get; set; }
        [StringLength(maximumLength:300)]
        public string Text { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public bool IsHome { get; set; }
    }
}
