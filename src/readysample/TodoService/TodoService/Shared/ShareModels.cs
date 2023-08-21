public class CategoryDto  
{  
    public string Category { get; set; }  
    public int CategoryId { get; set; }  
}  
  
public class TodoDto  
{  
    public int TodoId { get; set; }  
    public string Category { get; set; }  
    public string Title { get; set; }  
    public bool IsComplete { get; set; }  
}  
  
public class TodoPostRequest  
{  
    public int CategoryId { get; set; }  
    public string Title { get; set; }  
}  
  
public class TodoPutRequest  
{  
    public int TodoId { get; set; }  
    public bool isComplete { get; set; }  
}