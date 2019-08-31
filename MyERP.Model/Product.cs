using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public ProductType? ProductType { get; set;}
        public string Description { get; set; } //product specification
        public decimal? PurchaseCost { get; set; }
        public decimal? SellCost { get; set; }
        public bool CanBePurchased { get; set; }
        public bool CanBeSold { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}
