using BlazorApp6.Server.Database.Entity;
using BlazorApp6.Server.Repository;
using BlazorApp6.Server.Util;
using BlazorApp6.Shared;


namespace BlazorApp6.Server.Service;

public class AccountService
{
    private readonly CommonRepository _repository;
    private readonly Security _security;

    public AccountService(CommonRepository repository, Security security)
    {
        _repository = repository;
        _security = security;
    }

    public UserInformation SignIn(string email, string password)
    {
        var user = _repository.GetUser(email, _security.Hash(password));
        var token = _security.GenerateJWTToken(user);
        UserInformation info = new();
        info.JwtToken = token;
        info.Email = user.Email;
        return info;
    }

    public void SignUp(string email, string password)
    {
        var user = new User() { Email = email, PasswordHash = _security.Hash(password) };
        _repository.CreateUser(user);
    }
}

