using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Supplier:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Guid? CityId { get; set; }
        public virtual City City { get; set; }

        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}
