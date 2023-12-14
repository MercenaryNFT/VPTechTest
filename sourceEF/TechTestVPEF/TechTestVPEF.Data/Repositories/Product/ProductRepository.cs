using TechTestVPEF.Data.Repositories.Interfaces;

namespace TechTestVPEF.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private TechTestVpContext _techTestVpContext;

        public ProductRepository(TechTestVpContext techTestVpContext)
        {
            _techTestVpContext = techTestVpContext;
        }

        public bool CheckProductExists(string productId)
        {
            return _techTestVpContext.VptProducts.Any(p => p.PrdId == productId);
        }

        public IEnumerable<VptProduct> GetProducts()
        {
            return _techTestVpContext.VptProducts.ToList();
        }
    }
}
