using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.Enums;

namespace TechTestVP.Lib.DTOs
{
    public class OrderLineDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public UOM UnitOfMeasure { get; set; }
    }
}
