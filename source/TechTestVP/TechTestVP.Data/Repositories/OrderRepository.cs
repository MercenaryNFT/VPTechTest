using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Data.Repositories.Interfaces;
using TechTestVP.Lib.DTOs;
using TechTestVP.Lib.Models;
using Dapper;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

namespace TechTestVP.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnectionFactory _db;
        public OrderRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _db = dbConnectionFactory;
        }

        public async Task<bool> CheckIfOrderExists(string customerRef, string customerId)
        {
            string sql = @"SELECT COUNT(*)
                        FROM vpt_Order o
                        INNER JOIN vpt_Customer c on o.ord_cus_guid = c.cus_guid
                        WHERE o.ord_customer_ref = @CustomerRef
                        AND c.cus_id = @CustomerId";

            Parameters parameters = new Parameters();
            parameters.Add("@CustomerRef", customerRef);
            parameters.Add("@CustomerId", customerId);

            return await _db.ExecuteAsync(sql, parameters) > 0;
        }

        public async Task<int> InsertOrder(Order order)
        {
            try
            {
                int orderNumber = 0;
                Guid newOrderGuid = Guid.NewGuid();

                Parameters parameters = new Parameters();
                parameters.Add("@ord_guid", newOrderGuid);
                parameters.Add("@cus_id", order.Customer.Id);
                parameters.Add("@ord_customer_ref", order.CustomerRef);
                parameters.Add("@ord_required_date", order.RequiredDate.Value);

                IDataReader r = await _db.ExecuteProcedure("vpp_Order_Create", parameters);
                if (r.Read())
                {
                    newOrderGuid = (Guid)r["ord_guid"];
                    orderNumber = Convert.ToInt32(r["ord_order_number"]);
                }
                else
                {
                    return 0;
                }

                Task[] tasks = new Task[order.Lines.Count];
                for(int i = 0; i< order.Lines.Count; i++)
                {
                    tasks[i] = InsertOrderLine(order.Lines[i], newOrderGuid);
                }
                await Task<OrderLine>.WhenAll(tasks);

                return orderNumber;
                
            }
            catch(Exception)
            {
                return 0;
            }
        }

        private async Task<bool> InsertOrderLine(OrderLine line, Guid ord_guid)
        {
            Parameters parameters = new Parameters();
            parameters.Add("@ord_guid", ord_guid);
            parameters.Add("@prd_id", line.ProductId);
            parameters.Add("@orl_qty", line.Quantity);
            parameters.Add("@orl_uom", line.UnitOfMeasure);

            IDataReader r = await _db.ExecuteProcedure("vpp_Order_Line_Create", parameters);

            if (r.Read())
            {
                return true;
            }

            return false;

        }
    }
}
