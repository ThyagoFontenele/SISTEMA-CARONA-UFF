using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaronaUFF.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController(IUsuarioRepository usuarioRepository) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IList<Usuario>> Get() =>
        (await usuarioRepository.GetAll()).ToList();

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await usuarioRepository.GetById(id);

        if (customer is null)
        {
            return NotFound();
        }
        
        return Ok(customer);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(Usuario usuario)
    {
        var validationResult = await new UsuarioRegistration(usuarioRepository).Register(usuario);

        if (!validationResult.IsValid)
        {
            return Conflict(validationResult.Errors);
        }

        return Ok(validationResult.Data);
    }
}