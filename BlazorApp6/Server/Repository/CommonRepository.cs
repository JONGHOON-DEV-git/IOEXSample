using BlazorApp6.Server.Database.Context;
using BlazorApp6.Server.Database.Entity;

namespace BlazorApp6.Server.Repository;

public class CommonRepository
{
    private readonly TodoServiceContext _context;
    public CommonRepository(TodoServiceContext context)
    {
        _context = context;
    }

    public void CreateUser(User user)
    {
        var org = _context.Users.FirstOrDefault(x => x.Email == user.Email);
        if (org is null) throw new Exception("중복된 이메일");
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetUser(string eMail , string passWord )
    {
        var org = _context.Users.FirstOrDefault(x => x.Email == eMail && x.PasswordHash == passWord);
        if (org == null) throw new Exception("아이디 또는 패스워드가 맞지 않습니다.");
        return org;
    }

    public void CreateTodo(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public void UpdateTodo(Todo todo)
    {
        var org = _context.Todos.FirstOrDefault(x => x.TodoId == todo.TodoId);
        org.Task = todo.Task;
        org.IsCompleted = todo.IsCompleted;
        _context.SaveChanges();
    }

    public List<Todo> GetTodoAll()
        => _context.Todos.ToList();

    public List<Todo> GetTodo(int userID)
        => _context.Todos.Where(x => x.UserId == userID).ToList();
    
}