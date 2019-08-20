using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
   public class Bank:BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Guid? CityId { get; set; }
        public virtual City City { get; set; }
        public string Account { get; set; }

        public decimal? OpenBalance { get; set; }
        public decimal? CloseBalance { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }


    }
}
