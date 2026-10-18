using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productRepo;
        private readonly IProductsRepository _productRepo1;
        public ProductsController(IProductsRepository productRepo, IProductsRepository productRepo1)
        {
            //Without Interface we can create object of repository class using new without any parameter
            //_productRepo = new ProductRepository();
            //Must receive object of Interface using parameter when we use Interface
            _productRepo = productRepo;
            _productRepo1 = productRepo1;
        }
        [HttpPost]
        public IActionResult AddProduct(ProductsModel prod)
        {
            _productRepo.AddProduct(prod);
            var prods = _productRepo1.getAllProduct();
            return Ok(prods);
        }
        [HttpGet]
        public IActionResult GetServiceName()
        {
            var name = _productRepo.GetName();
            return Ok(name);
        }
    }
}
