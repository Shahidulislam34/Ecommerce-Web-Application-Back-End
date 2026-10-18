using EcommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DefaultWayController : ControllerBase
    {
        [HttpGet]//From Query string: No need to set targe type
        public IActionResult GetFromQueryString(int salary, string name)
        {
            return Ok($"Name: {name}, Salary: {salary}");
        }

        [HttpGet("{name}/{salary}")]//From Route
        public IActionResult GetFromRoute(int salary, string name)
        {
            return Ok($"Name: {name}, Salary: {salary}");
        }

        [HttpGet("{salary:int}")]
        public IActionResult GetFromAll(int salary, string name, BooksModel obj)
        {
            return Ok($"Name: {name}, Salary: {salary}" +
                $"Model.Id: {obj.Id}" +
                $"Model.Title:{obj.Title}" +
                $"Model.Description: {obj.Description}");
        }
    }
}
