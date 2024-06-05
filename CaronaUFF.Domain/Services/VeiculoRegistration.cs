using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services.Validation;

namespace CaronaUFF.Domain.Services
{
    public class VeiculoRegistration(IVeiculoRepository veiculoRepository)
    {
        public async Task<ValidationResult<Veiculo>> Register(Veiculo veiculo)
        {
            var validationResult = await new VeiculoRegistrationValidation(veiculoRepository).Validate(veiculo);

            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            validationResult.Data = veiculo;
            await veiculoRepository.Save(veiculo);

            return validationResult;
        }
    }
}
