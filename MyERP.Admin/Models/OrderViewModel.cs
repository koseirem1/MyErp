using MyERP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Müşteri Adı")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Display(Name = "Sipariş Onay Tarihi")]
        public DateTime? Validity { get; set; }
        [MaxLength(100)]
        [Display(Name = "Oluşturan Kişi")]
        public string Created { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Ürün Adı")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Ürün Açıklaması")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Ürün Birim Fiyatı ")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Ürün Adedi ")]
        public int? Quantity { get; set; }
        [Display(Name = "Ürün Vergisi")]
        [MaxLength(20)]
        public Guid? TaxId { get; set; }
        public virtual Tax Tax { get; set; }
        [Display(Name = "Ara Toplam")]
        public decimal? Subtotal { get; set; }
        [Display(Name = "Genel Toplam")]
        public decimal? GrandTotal { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}