using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _bookRepository;
        public BooksController(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BooksModel book)
        {
            await _bookRepository.AddBook(book);
            return Ok(book);
        }
    }
}
