using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public enum ProductType
    {
        [Display(Name="Tüketim Malzemesi")]
        Consumable=1,
        [Display(Name = "Hizmet")]
        Service =2

    }
}
