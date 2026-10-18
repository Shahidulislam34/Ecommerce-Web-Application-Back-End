using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FromHeaderController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetData([FromRoute] int id, [FromHeader] string name, [FromHeader] string phone)
        {
            return Ok($"ID: {id}, Name:{name}, Phone: {phone}");
        }
    }
}
