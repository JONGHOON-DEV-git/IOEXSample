using System.Text;
using System.Text.Json;

namespace TodoService.Client;

public static class HttpClientExtension
{
    public static async Task<T> PostAsync<T>(this HttpClient client, string url, object param)  
    {  
        var camel = new JsonSerializerOptions  
        {  
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase  
        };  
        var json = JsonSerializer.Serialize(param,camel);  
        using StringContent content = new(json, Encoding.UTF8, "application/json");  
  
        var response = await client.PostAsync(url, content);  
        response.EnsureSuccessStatusCode();  
  
        var resultString = await response.Content.ReadAsStringAsync();  
        if (resultString is null) throw new NullReferenceException();  
        var data = JsonSerializer.Deserialize<T>(resultString,camel)!;  
        return data;  
    }
}