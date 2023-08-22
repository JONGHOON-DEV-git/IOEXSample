using Microsoft.AspNetCore.ResponseCompression;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region db&swagger DI
// #region 데이터베이스컨텍스트 설정부분  
// var connection = builder.Configuration.GetConnectionString("Default");  
// builder.Services.AddDbContext<TodoService.Server.Database.Context.TodoServiceContext>(option =>  
// {  
//     option.UseMySql(connection, ServerVersion.AutoDetect(connection));  
// });  
//
// #endregion
//
// #region Swagger 생성기 주입
// builder.Services.AddSwaggerGen(c =>  
// {  
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });  
// });  
// #endregion
#endregion
  
var app = builder.Build();  

#region 스웨거 사용설정
// app.UseSwagger();  
// app.UseSwaggerUI(x =>  
// {  
//     x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  
//   
// });
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();