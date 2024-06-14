using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services.Validation;

namespace CaronaUFF.Domain.Services
{
    public class CaronaRegistration(ICaronaRepository caronaRepository)
    {
        public async Task<ValidationResult<Carona>> Register(Carona carona)
        {
            var validationResult = await new CaronaRegistrationValidation().Validate(carona);

            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            await caronaRepository.Save(carona);

            return validationResult;
        }
        public async Task<ValidationResult<Carona>> Update(Carona carona)
        {
            var validationResult = await new CaronaRegistrationValidation().Validate(carona);

            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            var caronaPersisted = await caronaRepository.GetById(carona.Id);

            if (caronaPersisted != null)
            {
                caronaPersisted.LocalSaida = carona.LocalSaida;
                caronaPersisted.LocalChegada = carona.LocalChegada;
                caronaPersisted.Vagas = carona.Vagas;
                caronaPersisted.Encerrada = carona.Encerrada;
                caronaPersisted.Cancelada = carona.Cancelada;
                caronaPersisted.DataHora = carona.DataHora;
                caronaPersisted.Observacoes = carona.Observacoes;

                await caronaRepository.Save(caronaPersisted);
                validationResult.Data = caronaPersisted;
                return validationResult;
            }
            else
            {
                validationResult.AddError("Carona não encontrada");
                return validationResult;
            }
        }
    }
}
