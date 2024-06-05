using System.Net;
using CaronaUFF.Api.Model;
using CaronaUFF.Api.Service;
using CaronaUFF.Domain.DTO;
using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaronaUFF.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(IUsuarioRepository usuarioRepository) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] Login login)
    {
        if (login.Email is null || login.Password is null)
        {
            return StatusCode((int)HttpStatusCode.Forbidden);
        }
        
        var user = await usuarioRepository.GetUser(u => u.Email == login.Email);

        if (user is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Senha))
        {
            return NotFound(new { message = "Email ou senha inválidos." });
        }

        var token = TokenService.GenerateToken(user);

        return Ok(new
        {
            user = new UsuarioDTO
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email
            },
            token
        });
    }
}