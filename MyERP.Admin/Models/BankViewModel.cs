using MyERP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class BankViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Banka Adı")]
        public string Name { get; set; }
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Ülke Adı")]

        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        public virtual City City { get; set; }

        [Display(Name = "Hesap No")]
        [Required]
        [MaxLength(20)]
        public string Account { get; set; }
        [Display(Name = "Açılış Bakiyesi")]
        public decimal? OpenBalance { get; set; }
        [Display(Name = "Kapanış Bakiyesi")]
        public decimal? CloseBalance { get; set; }


        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}