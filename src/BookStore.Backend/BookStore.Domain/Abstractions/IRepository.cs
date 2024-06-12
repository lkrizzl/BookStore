using BookStore.Domain.Models;

namespace BookStore.Domain.Abstractions;

public interface IRepository<TEntity>
{
    Task SaveChangesAsync();

    Task AddAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);


}
