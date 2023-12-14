using TechTestVPEF.Data;
using TechTestVPEF.Data.Repositories.Interfaces;
using TechTestVPEF.Engine.Interfaces;
using TechTestVPEF.Lib;
using TechTestVPEF.Lib.DTO;

namespace TechTestVPEF.Engine.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public ReponseDTO InsertOrder(OrderDTO order)
        {
            try
            {
                VptOrder newOrder = ModelHelpers.ConvertToOrder(order);

                foreach(var line in newOrder.VptOrderLines)
                {
                    if (!_productRepository.CheckProductExists(line.OrlPrd.PrdId))
                    {
                        throw new Exception($"{line.OrlPrd.PrdId} is not a valid product");
                    }
                }

                newOrder = _orderRepository.InsertOrder(newOrder);

                return new ReponseDTO
                {
                    Data = newOrder,
                    Errors = null,
                    IsSuccess = true,
                    Message = $"New Order Created!"
                };
            }
            catch(Exception ex)
            {
                return new ReponseDTO
                {
                    Data = null,
                    Errors = null,
                    IsSuccess = false,
                    Message = $"Failed with exception :{ex}"
                };
            }
        }
    }
}
