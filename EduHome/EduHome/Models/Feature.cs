using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50, ErrorMessage = "max uzunluq 50")]
        public string Name { get; set; }
        [StringLength(maximumLength:20, ErrorMessage = "max uzunluq 20")]
        public string Value { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
