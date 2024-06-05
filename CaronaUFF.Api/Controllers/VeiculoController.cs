using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services;
using CaronaUFF.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaronaUFF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController(IVeiculoRepository veiculoRepository) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IList<Veiculo>> Get() =>
    (await veiculoRepository.GetAll()).ToList();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var veiculo = await veiculoRepository.GetById(id);

            if (veiculo is null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Veiculo veiculo)
        {
            var validationResult = await new VeiculoRegistration(veiculoRepository).Register(veiculo);

            if (!validationResult.IsValid)
            {
                return Conflict(validationResult.Errors);
            }

            return Ok(validationResult.Data);
        }
    }
}
