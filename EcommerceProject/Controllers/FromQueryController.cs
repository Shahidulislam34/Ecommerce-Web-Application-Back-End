using EcommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FromQueryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData1([FromQuery]int id)
        {
            return Ok(id);
        }
        [HttpGet("{id}")]//this id for route parameter. Not for query string
        public IActionResult GetData2([FromQuery]int id)
        {
            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetData3([FromQuery]int salary, [FromQuery]BooksModel book)//Integer Default value = 0
        {
            return Ok($"Salary: {salary}, Book Title: {book.Title}, Book.Id: {book.Id}");
        }
    }
}
