using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CaronaUFF.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CaronaUFF.Api.Service;

public class TokenService
{
    public static string GenerateToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject =  new ClaimsIdentity( new []
            {
                new Claim("Id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}