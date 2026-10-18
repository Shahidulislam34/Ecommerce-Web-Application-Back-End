using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public interface IProductsRepository
    {
        List<ProductsModel> AddProduct(ProductsModel pro);
        List<ProductsModel> getAllProduct();
        string GetName();
    }
}