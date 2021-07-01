using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Subscribe
    {
        public int Id { get;set; }
        [StringLength(maximumLength:30)]
        [Required(ErrorMessage ="duzgun yaz")]
        [EmailAddress(ErrorMessage = "Tdsdssdsfdghfgjghf.")]
        public string Email { get; set; }
    }
}
