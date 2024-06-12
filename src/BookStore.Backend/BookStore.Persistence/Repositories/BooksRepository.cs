using BookStore.Domain.Abstractions.Repositories;
using BookStore.Domain.Models;
using BookStore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.Reposotories;

public class BooksRepository : Repository<Book>, IBooksRepository
{
    public BooksRepository(BookStoreDbContext context) : base(context)
    {
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books
            .ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

}
