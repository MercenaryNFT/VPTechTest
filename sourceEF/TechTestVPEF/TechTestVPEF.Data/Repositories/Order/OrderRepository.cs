using TechTestVPEF.Data.Repositories.Interfaces;

namespace TechTestVPEF.Data.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {
        private TechTestVpContext _techTestVpContext;

        public OrderRepository(TechTestVpContext techTestVpContext)
        {
            _techTestVpContext = techTestVpContext;
        }

        public VptOrder InsertOrder(VptOrder order)
        {
            VptOrder newOrder = _techTestVpContext.Add(order).Entity;
            _techTestVpContext.SaveChanges();

            return newOrder;

        }
    }
}
