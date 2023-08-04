using BlazorApp6.Server.Service;
using BlazorApp6.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp6.Server.Controllers;

public class AccountController : ControllerBase
{
    private readonly AccountService _service;

    public AccountController(AccountService service)
    {
        _service = service;
    }

    // [HttpPost]
    // public bool SignUp([FromBody] SignUpRequest request)
    // {
    //     
    // }
    //
    // public User SignIn()
    // {
    //     
    // }
}

