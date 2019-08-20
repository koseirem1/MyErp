﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class CountryViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ülke Adı")]
        public string Name { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}