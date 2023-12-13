using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestVP.Lib.Models
{
    public class Product
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal SalePrice { get; set; }
        public Decimal CostPrice { get; set; }
    }
}
