using BookStore.Domain.Core.PrimitiveTypes;

namespace BookStore.Application.Errors;

internal static class ApplicationErrors
{
    public static class Books
    {
        public static Error NotFound(Guid id) => new Error("BooksErrors.NotFound", $"Book with {id} id is not found");
    }


}
