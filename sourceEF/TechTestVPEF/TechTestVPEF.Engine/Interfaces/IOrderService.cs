using TechTestVPEF.Lib.DTO;

namespace TechTestVPEF.Engine.Interfaces
{
    public interface IOrderService
    {
        public ReponseDTO InsertOrder(OrderDTO order);
    }
}
