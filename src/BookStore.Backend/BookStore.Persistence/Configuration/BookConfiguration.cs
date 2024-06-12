using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Title)
            .HasMaxLength(Book.MAX_TITLE_LENGHT)
            .IsRequired();

        builder.Property(b => b.Description)
            .IsRequired();

        builder.Property(b => b.Price)
            .IsRequired();
    }
}
