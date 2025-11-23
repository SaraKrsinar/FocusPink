using FocusPink.Core.Interfaces;
using FocusPink.Core.Entities;
using FocusPink.Api.DTOs;

namespace FocusPink.Api.Endpoints
{
    public static class TodoEndpoints
    {
        public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/todos");

            group.MapGet("/", async (ITodoRepository repo) =>
                Results.Ok(await repo.GetAllAsync()));

            group.MapPost("/", async (ITodoRepository repo, CreateTodoRequest input) =>
            {
                if (string.IsNullOrWhiteSpace(input.Title))
                    return Results.BadRequest("Title is required");

                var created = await repo.AddAsync(new TodoItem
                {
                    Title = input.Title.Trim(),
                    IsDone = false,
                    CreatedAt = DateTime.UtcNow
                });

                return Results.Created($"/api/todos/{created.Id}", created);
            });

            group.MapPut("/{id:int}/toggle", async (ITodoRepository repo, int id) =>
            {
                var updated = await repo.ToggleAsync(id);
                return updated is null ? Results.NotFound() : Results.Ok(updated);
            });

            group.MapDelete("/{id:int}", async (ITodoRepository repo, int id) =>
            {
                var ok = await repo.DeleteAsync(id);
                return ok ? Results.NoContent() : Results.NotFound();
            });

            return routes;
        }
    }
}