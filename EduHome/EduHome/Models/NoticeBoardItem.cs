using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class NoticeBoardItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(maximumLength: 200)]
        public string Text { get; set; }
    }
}
