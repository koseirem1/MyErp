using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Quotation:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string Address { get; set; }

        public DateTime? Date { get; set; }

        public string RefText { get; set; } //reference text

        public string Created { get; set; }

        public string MobilePhone { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }

        public Guid? TaxId { get; set; }
        public virtual Tax Tax { get; set; }

        public decimal? Subtotal { get; set; }
        public decimal? GrandTotal { get; set; }

    }
}
