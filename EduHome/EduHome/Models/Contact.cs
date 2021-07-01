using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        [StringLength(maximumLength: 30)]
        [Required]
        [EmailAddress(ErrorMessage = "Tdsdssdsfdghfgjghf.")]
        public string Email { get; set; }
        [StringLength(maximumLength: 200)]
        [Required]
        public string Subject { get; set; }
        [StringLength(maximumLength: 200)]
        [Required]
        public string Message { get; set; }
    }
}
