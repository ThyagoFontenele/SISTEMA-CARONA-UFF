using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services.Validation;

namespace CaronaUFF.Domain.Services;

public class UsuarioRegistration(IUsuarioRepository usuarioRepository)
{
    public async Task<ValidationResult<Usuario>> Register(Usuario usuario)
    {
        var validationResult = await new UsuarioRegistrationValidation(usuarioRepository).Validate(usuario);

        if (!validationResult.IsValid)
        { 
            return validationResult;
        }
        
        validationResult.Data = usuario;
        await usuarioRepository.Save(usuario);

        return validationResult;
    }
}