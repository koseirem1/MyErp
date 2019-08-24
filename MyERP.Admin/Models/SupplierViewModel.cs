using MyERP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyERP.Admin.Models
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Ülke")]
        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        public virtual City City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        [Required]
        [Display(Name = "Cep Telefonu")]
        public string MobilePhone { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }


        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }
        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
    }
}