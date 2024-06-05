using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services.Validation;
using CaronaUFF.Domain.Specifications.VeiculoSpecifications;

namespace CaronaUFF.Domain.Services
{
    public class VeiculoRegistrationValidation(IVeiculoRepository veiculoRepository) : ValidationService<Veiculo>
    {
        protected override void SetValidations()
        {
            AddSpecification(new VeiculoUniquePlacaSpecification(veiculoRepository));
        }
    }
}
