using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Tax:BaseEntity
    {

        public string Name { get; set; }
        public decimal Percent { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
