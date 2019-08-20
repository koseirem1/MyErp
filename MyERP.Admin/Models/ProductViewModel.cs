using MyERP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Ürün Tipi")]
        public ProductType? ProductType { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } //product specification
        [Display(Name = "Satın Alma Maliyeti")]
        public decimal? PurchaseCost { get; set; }
        [Display(Name = "Satış Maliyeti")]
        public decimal? SellCost { get; set; }
        [Display(Name = "Satın Alınabilir")]
        public bool CanBePurchased { get; set; }
        [Display(Name = "Satılabilir")]
        public bool CanBeSold { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}