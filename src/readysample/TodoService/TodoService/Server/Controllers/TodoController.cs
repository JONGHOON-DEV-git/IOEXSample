using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace TodoService.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    
    // [HttpPost]
    // public TodoDto Create([FromBody] TodoPostRequest req)
    //
    //
    // [HttpPut]
    // public void Update([FromBody] TodoPutRequest req)
    //
    //
    // [HttpGet]
    // public List<TodoDto> Get()
    //
    //
    // [HttpGet]
    // [Route("~/api/category")]
    // public List<CategoryDto> GetCategory()
    //
    
}