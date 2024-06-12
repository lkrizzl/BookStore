using BookStore.Domain.Core.PrimitiveTypes;

namespace BookStore.Domain.Errors;

public static class DomainErrors
{
    public static class Books
    {
        public static Error InvalidTitle = new("Books.InvalidTitle", "Can not be empty or longer then 250 symbols");
    }
}
