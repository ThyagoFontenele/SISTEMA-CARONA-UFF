using System.Security.Claims;

namespace CaronaUFF.Api;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

        if (userId is null)
        {
            throw new Exception("Usuário não autenticado");
        }

        return int.Parse(userId);
    }
}