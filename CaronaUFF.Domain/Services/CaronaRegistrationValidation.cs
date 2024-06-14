using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Services.Validation;
using CaronaUFF.Domain.Specifications.CaronaSpecifications;

namespace CaronaUFF.Domain.Services;

public class CaronaRegistrationValidation : ValidationService<Carona>
{
    protected override void SetValidations()
    {
        AddSpecification(new CaronaDataHoraSpecification());
        AddSpecification(new CaronaCanceladaEncerradaSpecification());
        AddSpecification(new CaronaVagasLengthSpecification());
    }
}
