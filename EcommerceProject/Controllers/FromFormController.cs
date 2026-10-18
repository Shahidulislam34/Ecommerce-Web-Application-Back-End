using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FromFormController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetData([FromRoute] int id, [FromForm]string name, [FromForm]string phone)
        {
            return Ok($"ID: {id}, Name:{name}, Phone: {phone}");
        }
    }
}
