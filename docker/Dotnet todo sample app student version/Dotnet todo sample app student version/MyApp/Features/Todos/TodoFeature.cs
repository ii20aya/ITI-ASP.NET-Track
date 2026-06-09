using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Collections.Concurrent;

namespace MyApp.Features.Todos;

public record Todo(Guid Id, string Title, bool IsCompleted);
public record CreateTodoRequest(string Title);
public record UpdateTodoRequest(string Title, bool IsCompleted);

public static class TodoFeature
{
    // Thread-safe in-memory store
    private static readonly ConcurrentDictionary<Guid, Todo> _todos = new();

    public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/todos");

        // GET all
        group.MapGet("/", () => _todos.Values);

        // GET by ID
        group.MapGet("/{id:guid}", (Guid id) => 
            _todos.TryGetValue(id, out var todo) 
                ? Results.Ok(todo) 
                : Results.NotFound());

        // POST (Create)
        group.MapPost("/", (CreateTodoRequest request) => 
        {
            var todo = new Todo(Guid.NewGuid(), request.Title, false);
            _todos[todo.Id] = todo;
            return Results.Created($"/api/todos/{todo.Id}", todo);
        });

        // PUT (Update)
        group.MapPut("/{id:guid}", (Guid id, UpdateTodoRequest request) => 
        {
            if (!_todos.ContainsKey(id)) return Results.NotFound();
            
            var updated = new Todo(id, request.Title, request.IsCompleted);
            _todos[id] = updated;
            return Results.NoContent();
        });

        // DELETE
        group.MapDelete("/{id:guid}", (Guid id) => 
        {
            return _todos.TryRemove(id, out _) 
                ? Results.NoContent() 
                : Results.NotFound();
        });
    }

    // Seed data helper
    public static void SeedData()
    {
        var id1 = Guid.NewGuid();
        _todos[id1] = new Todo(id1, "Learn Docker Multi-stage builds", true);
        
        var id2 = Guid.NewGuid();
        _todos[id2] = new Todo(id2, "Audit bloated images", false);
        
        var id3 = Guid.NewGuid();
        _todos[id3] = new Todo(id3, "Deploy optimized API", false);
    }
}
