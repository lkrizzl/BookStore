namespace BookStore.WebApi.Contracts;

public record BooksRequest(
        string Title,
        string Description,
        decimal Price);
