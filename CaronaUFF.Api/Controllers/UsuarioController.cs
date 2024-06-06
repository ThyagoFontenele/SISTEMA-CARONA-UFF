using System.Security.Claims;
using CaronaUFF.Domain.DTO;
using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaronaUFF.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioRepository usuarioRepository) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IList<Usuario>> Get() =>
        (await usuarioRepository.GetAll()).ToList();

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await usuarioRepository.GetById(id);
        
        if (usuario is null)
        {
            return NotFound();
        }
        
        return Ok(UsuarioDTO.ToDTO(usuario));
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update(Usuario usuario)
    {
        if (await usuarioRepository.GetById(usuario.Id) is null)
        {
            return NotFound();
        }
        
        var validationResult = await new UsuarioRegistration(usuarioRepository).Register(usuario);
        
        if (!validationResult.IsValid)
        {
            return Conflict(validationResult.Errors);
        }
        
        return Ok(UsuarioDTO.ToDTO(usuario));
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

        return Ok();
    }
}