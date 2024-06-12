using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Persistence;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
        base.OnModelCreating(modelBuilder);
    }
}
