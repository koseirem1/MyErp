using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
   public class Order:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime Validity { get; set; }

        public string Created { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Guid? TaxId { get; set; }
        public virtual Tax Tax { get; set; }

        public decimal Subtotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
