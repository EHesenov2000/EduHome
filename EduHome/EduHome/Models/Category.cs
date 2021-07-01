﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(maximumLength:40, ErrorMessage = "max uzunluq 40")]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
