using BookStore.Application.Errors;
using BookStore.Domain.Abstractions.Repositories;
using BookStore.Domain.Core.PrimitiveTypes;
using BookStore.Domain.Models;

namespace BookStore.Application.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _booksRepository.GetBooksAsync();
    }

    public async Task<Result> CreateBookAsync(string title, string description, decimal price)
    {
        var result = Book.Create(
            Guid.NewGuid(),
            title,
            description,
            price);

        if (result.IsFailure)
        {
            return result;
        }

        await _booksRepository.AddAsync(result.Value);

        return Result.Success();
    }

    public async Task<Result> ChangeBookInfoAsync(Guid id, string title, string description, decimal price)
    {
        var book = await _booksRepository.GetBookByIdAsync(id);

        if (book is null)
        {
            return Result.Failure(ApplicationErrors.Books.NotFound(id));
        }

        var resultChanges = book.ChangeInfo(title, description, price);

        if (resultChanges.IsFailure)
        {
            return resultChanges;
        }

        await _booksRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteBookAsync(Guid id)
    {
        var book = await _booksRepository.GetBookByIdAsync(id);

        if(book is null) 
        { 
            return Result.Failure(ApplicationErrors.Books.NotFound(id));
        }

        await _booksRepository.DeleteAsync(book);

        return Result.Success();
    }
}
