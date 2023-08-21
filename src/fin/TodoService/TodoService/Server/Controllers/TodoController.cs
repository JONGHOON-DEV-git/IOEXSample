using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using TodoService.Server.Database.Context;
using TodoService.Server.Utils;

namespace TodoService.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoServiceContext _context;

    public TodoController(TodoServiceContext context)
    {
        _context = context;
    }

    [HttpPost]
    public TodoDto Create([FromBody] TodoPostRequest req)
    {
        var todo = req.CreateTodo();
        _context.Todos.Add(todo); 
        //여기서 설명할 것 
        _context.SaveChanges();

        return todo.CreateTodoDto();
    }

    [HttpPut]
    public void Update([FromBody] TodoPutRequest req)
    {
        var item = _context.Todos.FirstOrDefault(x => x.Id == req.TodoId);
        item.IsComplete = req.isComplete;
        _context.SaveChanges();
    }

    [HttpGet]
    public List<TodoDto> Get()
    {
        return _context.Todos.Include(x => x.Category).ToList().CreateTodoDtos();
    }

    [HttpGet]
    [Route("~/api/category")]
    public List<CategoryDto> GetCategory()
    {
        return _context.Categories.ToList().CreateCategoryDtos();
    }
    
}