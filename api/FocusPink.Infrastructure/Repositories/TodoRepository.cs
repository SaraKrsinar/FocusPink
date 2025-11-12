using FocusPink.Core.Interfaces;
using FocusPink.Core.Entities;
using FocusPink.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FocusPink.Infrastructure.Repositories
{
    public class TodoRepository(AppDbContext db) : ITodoRepository
    {
        public async Task<List<TodoItem>> GetAllAsync() =>
            await db.Todos.OrderByDescending(t => t.Id).ToListAsync();

        public Task<TodoItem?> GetByIdAsync(int id) => db.Todos.FindAsync(id).AsTask();

        public async Task<TodoItem> AddAsync(TodoItem item)
        {
            db.Todos.Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<TodoItem?> ToggleAsync(int id)
        {
            var item = await db.Todos.FindAsync(id);
            if (item is null) return null;
            item.IsDone = !item.IsDone;
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await db.Todos.FindAsync(id);
            if (item is null) return false;
            db.Todos.Remove(item);
            await db.SaveChangesAsync();
            return true;
        }
    }
}