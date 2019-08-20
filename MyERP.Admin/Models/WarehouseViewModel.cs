using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class WarehouseViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Depo Adı")]
        public string Name { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Depo Adresi")]
        public string WarehouseLocation { get; set; } //base entity location olduğundan bu ismi verdim
        [Display(Name = "Depo Yöneticisi")]
        [MaxLength(50)]
        public string Manager { get; set; }
        [Display(Name = "Depo Kapasitesi")]
        public int? Capacity { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}