using TodoService.Server.Database.Entity;

namespace TodoService.Server.Utils;

public static class DtoFactory  
{  
    public static Todo CreateTodo(this TodoPostRequest req)  
    {  
        Todo todo = new()  
        {  
            Title = req.Title,  
            CategoryId = req.CategoryId,  
        };  
        return todo;  
    }  
    public static TodoDto CreateTodoDto(this Todo todo)  
        => new TodoDto  
        {  
            TodoId = todo.Id,  
            Category = todo.Category?.Name ?? "",  
            Title = todo.Title,  
            IsComplete = todo.IsComplete  
        };  
  
    public static List<TodoDto> CreateTodoDtos(this List<Todo> todo)  
    {  
        return todo.Select(x => x.CreateTodoDto()).ToList();  
    }  
  
    public static List<CategoryDto> CreateCategoryDtos(this List<Category> categories)  
    {  
        return categories.Select(x => new CategoryDto()  
        {  
            Category = x.Name,  
            CategoryId = x.Id  
        }).ToList();  
    }  
}