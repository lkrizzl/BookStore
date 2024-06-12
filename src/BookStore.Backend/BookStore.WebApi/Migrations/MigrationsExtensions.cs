using BookStore.Persistence;
using Microsoft.EntityFrameworkCore;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        using BookStoreDbContext context =
            serviceScope.ServiceProvider.GetRequiredService<BookStoreDbContext>();

        context.Database.Migrate();
    }
}