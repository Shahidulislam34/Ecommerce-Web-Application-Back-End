using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public interface IBooksRepository
    {
        Task<BooksModel> AddBook(BooksModel book);
        Task<List<BooksModel>> GetAllBooks();
    }
}