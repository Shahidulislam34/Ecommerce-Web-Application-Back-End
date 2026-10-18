using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[BindProperties]//work for all but without get
    [BindProperties(SupportsGet =true)]//work for all method
    public class CountriesController : ControllerBase
    {
        //[BindProperty]
        //public string Name { get; set; }
        //[BindProperty]
        //public int Population { get; set; }

        //[BindProperty]
        //public CountryModel obj { get; set; }

        [HttpPost]
        public IActionResult AddCountryInfo()
        {
            //return Ok($"Country Name: {Name}, Population: {Population}");
            return Ok($"Country Name: {obj.Name}, Population: {obj.Population}");
        }

        //[BindProperty(SupportsGet = true)]
        public CountriesModel obj { get; set; }

        [HttpGet]
        public IActionResult GetCountryInfo()
        {
            return Ok($"Country Name: {obj.Name}, Population: {obj.Population}");
        }


        //Dependency Indection using method
        [Route("GetServiceName")]
        [HttpGet]
        public IActionResult GetServiceName([FromServices]IProductsRepository productRepo)
        {
            var name = productRepo.GetName();
            return Ok(name);
        }
    }
}
