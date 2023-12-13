using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.DTOs;
using TechTestVP.Lib.Enums;

namespace TechTestVP.Lib.Models
{
    public class OrderLine
    {
        public Guid Guid { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public UOM UnitOfMeasure { get; set; }

        public OrderLine ToModel(OrderLineDTO l)
        {
            return new OrderLine
            {
                Quantity = l.Quantity,
                ProductId = l.ProductId,
                UnitOfMeasure = l.UnitOfMeasure
            };
        }
    }
}
