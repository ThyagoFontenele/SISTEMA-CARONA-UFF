using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services.Validation;
using CaronaUFF.Domain.Specifications.UsuarioSpecifications;

namespace CaronaUFF.Domain.Services;

public class UsuarioRegistrationValidation(IUsuarioRepository usuarioRepository) : ValidationService<Usuario>
{
    protected override void SetValidations()
    {
        AddSpecification(new UsuarioUniqueEmailSpecification(usuarioRepository));
        AddSpecification(new UsuarioUniqueCpfSpecification(usuarioRepository));
        AddSpecification(new UsuarioUniqueTelefoneSpecification(usuarioRepository));
    }
}