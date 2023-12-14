namespace TechTestVPEF.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<VptProduct> GetProducts();
        public bool CheckProductExists(string productId);
    }
}
