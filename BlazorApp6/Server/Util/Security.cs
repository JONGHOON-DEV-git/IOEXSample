using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BlazorApp6.Server.Database.Entity;
using Microsoft.IdentityModel.Tokens;

namespace BlazorApp6.Server.Util;

public class Security
{
    private readonly IConfiguration _config;

    public Security(IConfiguration config)
    {
        this._config = config;
    }

    public string GenerateJWTToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserEmail",user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string Hash(string reqPassword)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(reqPassword));
        StringBuilder builder = new StringBuilder();
        foreach (var t in hashedBytes)
        {
            builder.Append(t.ToString("x2"));
        }

        return builder.ToString();
    }
}