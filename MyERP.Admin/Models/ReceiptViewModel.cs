using MyERP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class ReceiptViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Müşteri Adı")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Display(Name = "Ürün Birim Fiyatı")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Banka Adı")]
        public Guid? BankId { get; set; }
        public virtual Bank Bank { get; set; }
        [Display(Name = "Alınan Miktar")]
        public decimal? ReceivedAmount { get; set; }
        [Display(Name = "Kalan Miktar")]
        public decimal? BalAmount { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        
    }
}