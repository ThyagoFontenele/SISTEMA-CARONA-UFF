using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services;
using CaronaUFF.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaronaUFF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController(IVeiculoRepository veiculoRepository) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<Veiculo>> Get() =>
    (await veiculoRepository.GetAll()).ToList();

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
        public async Task<IActionResult> Post(Veiculo veiculo)
        {
            var validationResult = await new VeiculoRegistration(veiculoRepository).Register(veiculo);

            if (!validationResult.IsValid)
            {
                return Conflict(validationResult.Errors);
            }

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(Veiculo veiculo)
        {
            var veiculoPersisted = await veiculoRepository.GetById(veiculo.Id);

            if (veiculoPersisted is null)
            {
                return NotFound();
            }

            var validationResult = await new VeiculoRegistration(veiculoRepository).Update(veiculo);

            if (!validationResult.IsValid)
            {
                return Conflict(validationResult.Errors);
            }

            return Ok(validationResult.Data);
        }
    }
}
