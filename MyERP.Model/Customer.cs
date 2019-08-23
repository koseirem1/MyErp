using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public TitleOfCourtesy? TitleOfCourtesy { get; set; }
        public Gender? Gender { get; set; }
        
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public string Company { get; set; }
        
        public string Photo { get; set; }
        public string Address { get; set; }

        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Guid? CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }

    }
}
