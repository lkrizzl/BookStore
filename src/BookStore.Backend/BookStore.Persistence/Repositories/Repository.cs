using BookStore.Domain.Abstractions;

namespace BookStore.Persistence.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly BookStoreDbContext _context;

    public Repository(BookStoreDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(TEntity entity)
    {
        _context.Add(entity);
        await SaveChangesAsync();

    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
