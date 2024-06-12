namespace BookStore.WebApi.Cintracts
{
    public record BooksResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price);
}
