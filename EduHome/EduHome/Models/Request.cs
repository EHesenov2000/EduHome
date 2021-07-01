using EduHome.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [StringLength(maximumLength: 20)]
        [Required]
        public string ContactPhone { get; set; }
        [StringLength(maximumLength: 200)]
        [Required]
        public string Address { get; set; }
        [StringLength(maximumLength: 200)]
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }


    }
}
