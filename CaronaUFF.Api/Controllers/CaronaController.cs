using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services;
using CaronaUFF.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CaronaUFF.Infrastructure.Repositories;

namespace CaronaUFF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaronaController(ICaronaRepository caronaRepository) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<Carona>> Get() =>
            (await caronaRepository.GetAll()).ToList();

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var carona = await caronaRepository.GetById(id);

            if (carona is null)
            {
                return NotFound();
            }
            return Ok(carona);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(Carona carona)
        {
            var validationResult = await new CaronaRegistration(caronaRepository).Register(carona);

            if (!validationResult.IsValid)
            {
                return Conflict(validationResult.Errors);
            }
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(Carona carona)
        {
            var caronaPersisted = await caronaRepository.GetById(carona.Id);

            if (caronaPersisted is null)
            {
                return NotFound();
            }

            var validationResult = await new CaronaRegistration(caronaRepository).Update(carona);

            if (!validationResult.IsValid)
            {
                return Conflict(validationResult.Errors);
            }

            return Ok(validationResult.Data);
        }
    }
}
