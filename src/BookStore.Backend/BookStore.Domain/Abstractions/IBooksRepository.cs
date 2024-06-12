using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;

namespace BookStore.Domain.Abstractions.Repositories
{
    public interface IBooksRepository : IRepository<Book>
    {
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<List<Book>> GetBooksAsync();
    }
}