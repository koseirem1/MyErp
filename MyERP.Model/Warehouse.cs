using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Warehouse:BaseEntity
    {
        public string Name { get; set; }
        public string WarehouseLocation { get; set; } //base entity location olduğundan bu ismi verdim
        public string Manager { get; set; }
        public int? Capacity { get; set; }
    }
}
