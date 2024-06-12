using BookStore.Domain.Core.PrimitiveTypes;
using BookStore.Domain.Errors;

namespace BookStore.Domain.Models;

public class Book
{
    public const int MAX_TITLE_LENGHT = 250;

    private Book(Guid id, string title, string description, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
    }

    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public static Result<Book> Create(Guid id, string title, string description, decimal price)
    {

        if (string.IsNullOrEmpty(title) || title.Length > Book.MAX_TITLE_LENGHT)
        {
            return Result.Failure<Book>(DomainErrors.Books.InvalidTitle);
        }

        var book = new Book(id, title, description, price);

        return Result.Success(book);
    }

    public Result ChangeInfo(string title, string description, decimal price)
    {
        if (string.IsNullOrEmpty(title) || title.Length > Book.MAX_TITLE_LENGHT)
        {
            return Result.Failure(DomainErrors.Books.InvalidTitle);
        }

        Title = title;
        Description = description;
        Price = price;

        return Result.Success();
    }
}
