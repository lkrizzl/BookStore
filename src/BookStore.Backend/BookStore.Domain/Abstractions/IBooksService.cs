using BookStore.Domain.Core.PrimitiveTypes;
using BookStore.Domain.Models;

namespace BookStore.Application.Services
{
    public interface IBooksService
    {
        Task<Result> ChangeBookInfoAsync(Guid id, string title, string description, decimal price);

        Task<Result> CreateBookAsync(string title, string description, decimal price);

        Task<Result> DeleteBookAsync(Guid id);

        Task<List<Book>> GetAllBooksAsync();

    }
}