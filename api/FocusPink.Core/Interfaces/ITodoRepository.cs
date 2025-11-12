using FocusPink.Core.Entities;

namespace FocusPink.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task<TodoItem> AddAsync(TodoItem item);
        Task<TodoItem?> ToggleAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}