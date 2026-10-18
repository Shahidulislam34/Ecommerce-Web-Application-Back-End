using EcommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FromRouteController : ControllerBase
    {
        [HttpGet("{name}/{zilla}")]////give url strictly maintain this order
        public IActionResult GetData([FromRoute] string name, [FromRoute] string zilla)
        {
            return Ok(name);
        }

        [HttpGet("{Id}/{Title}/{Description}/{salary}")]//give url strictly maintain this order
        public IActionResult GetModel([FromRoute]BooksModel obj, [FromRoute] int salary)
        {
            return Ok($"salary : {salary}, obj.Id: {obj.Id}, obj.Title: {obj.Title}, obj.Description:{obj.Description}");
        }

    }
}
