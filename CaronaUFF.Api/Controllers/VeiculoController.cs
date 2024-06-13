using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services;
using CaronaUFF.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaronaUFF.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeiculoController(IVeiculoRepository veiculoRepository) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IList<Veiculo>> Get() =>
        await veiculoRepository.GetUserVeiculos(User.GetUserId());

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var veiculo = await veiculoRepository.GetById(id);

        if (veiculo is null)
        {
            return NotFound();
        }
        return Ok(VeiculoDTO.ToDTO(veiculo));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(VeiculoDTO veiculoDto)
    {
        var veiculo = VeiculoDTO.ToEntity(veiculoDto);
        veiculo.Usuario = new Usuario { Id = User.GetUserId() };
            
        var validationResult = await new VeiculoRegistration(veiculoRepository)
            .Register(veiculo);

        if (!validationResult.IsValid)
        {
            return Conflict(validationResult.Errors);
        }

        return Ok(VeiculoDTO.ToDTO(veiculo));
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update(VeiculoDTO veiculoDto)
    {
        var veiculoPersisted = await veiculoRepository.GetById(veiculoDto.Id);

        if (veiculoPersisted is null)
        {
            return NotFound();
        }

        if (veiculoPersisted.Usuario.Id != User.GetUserId())
        {
            return Unauthorized();
        }

        var veiculo = VeiculoDTO.ToEntity(veiculoDto);
        var validationResult = await new VeiculoRegistration(veiculoRepository).Update(veiculo);

        if (!validationResult.IsValid)
        {
            return Conflict(validationResult.Errors);
        }

        return Ok(VeiculoDTO.ToDTO(validationResult.Data!));
    }
}