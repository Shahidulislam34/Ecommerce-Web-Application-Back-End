using EcommerceProject.Data;
using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly EcommerceDbContext _context;
        public BooksRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<BooksModel>> GetAllBooks()
        {
            //List<BookModel> book = new List<BookModel>();
            var book = await _context.booksTab.ToListAsync();
            return book;
        }
        public async Task<BooksModel> AddBook(BooksModel book)
        {
            await _context.booksTab.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
