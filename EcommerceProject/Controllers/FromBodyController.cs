using EcommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FromBodyController : ControllerBase
    {
        [HttpGet("{id}")]//this id is for fromroute
        public IActionResult GetData1([FromBody]int id)
        {
            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetData2([FromBody]BooksModel book)
        {
            return Ok(book);
        }
    }
}
