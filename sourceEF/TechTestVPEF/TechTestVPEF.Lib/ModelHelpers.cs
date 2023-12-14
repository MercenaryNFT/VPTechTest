using TechTestVPEF.Data;
using TechTestVPEF.Lib.DTO;

namespace TechTestVPEF.Lib
{
    public static class ModelHelpers
    {
        public static VptOrder ConvertToOrder(OrderDTO o )
        {
            List<VptOrderLine> lines = new List<VptOrderLine>();
            foreach (OrderLineDTO l in o.Lines)
            {
                lines.Add(ConvertToOrderLine(l));
            }
            return new VptOrder
            {
                OrdCustomerRef = o.CustomerRef,
                OrdRequiredDate = o.RequiredDate.Value,
                VptOrderLines = lines,
                OrdCus = new VptCustomer { CusId = o.Customer.Id }
            };
        }

        public static VptOrderLine ConvertToOrderLine(OrderLineDTO l)
        {
            return new VptOrderLine
            {
                OrlQty = l.Quantity,
                OrlPrd = new VptProduct { PrdId = l.ProductId },
                OrlUom = l.UnitOfMeasure
            };
        }
    }
}
