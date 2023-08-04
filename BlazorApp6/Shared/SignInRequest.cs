using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Shared;


public class SignInRequest
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(20)]
    [MinLength(4)]
    public string Password { get; set; }
}