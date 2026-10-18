using EcommerceProject.Models;

namespace EcommerceProject.Repository;

public class ProductsRepository : IProductsRepository
{
    private List<ProductsModel> prods = new List<ProductsModel>();
    public List<ProductsModel> AddProduct(ProductsModel pro)
    {
        pro.Id = prods.Count + 1;
        prods.Add(pro);
        return prods;
    }
    public List<ProductsModel> getAllProduct()
    {
        return prods;
    }
    public string GetName()
    {
        return "This is Product Repository";
    }

}
