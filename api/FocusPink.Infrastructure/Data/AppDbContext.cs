using Microsoft.EntityFrameworkCore;
using FocusPink.Core.Entities;

namespace FocusPink.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}