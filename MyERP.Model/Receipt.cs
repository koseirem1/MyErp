using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
   public class Receipt:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public decimal ReceivedAmount { get; set; } 
        public decimal BalAmount { get; set; } //kalan miktar + veya - olabilir.Balance Amount

    }
}
