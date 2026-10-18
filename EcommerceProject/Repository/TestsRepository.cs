using EcommerceProject.Models;

namespace EcommerceProject.Repository;

public class TestRepository:IProductsRepository
{
    public List<ProductsModel> AddProduct(ProductsModel pro)
    {
        throw new NotImplementedException();
    }

    public List<ProductsModel> getAllProduct()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return "This is Test Repository";
    }
}
