using System.ComponentModel.DataAnnotations;

namespace BlazorApp6.Shared;

public class SignUpRequest
{
    [EmailAddress]
    public string Email { get; set; }
    
    [MaxLength(20)]
    [MinLength(4)]
    public string Password { get; set; }
    
    [MaxLength(20)]
    [MinLength(4)]
    public string PasswordConfirm { get; set; }
}
