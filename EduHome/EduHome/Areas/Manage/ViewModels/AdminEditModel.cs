﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Manage.ViewModels
{
    public class AdminEditModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Id { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}
