using EcommerceProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Data
{
    public class EcommerceDbContext:IdentityDbContext<ApplicationUser>
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<CustomersModel> customersTab { get; set; }
        public DbSet<BooksModel> booksTab { get; set; }
    }
}
