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

        if (usuario.Id == default)
        {
            validationResult.Data = usuario;
            await usuarioRepository.Save(usuario);
            return validationResult;
        }
        
        var usuarioPersisted = await usuarioRepository.GetById(usuario.Id);
        
        usuarioPersisted!.Nome = usuario.Nome;
        usuarioPersisted.Email = usuario.Email;
        usuarioPersisted.CPF = usuario.CPF;
        usuarioPersisted.Telefone = usuario.Telefone;
        usuarioPersisted.Senha = usuario.Senha;
        usuarioPersisted.DataNascimento = usuario.DataNascimento;
        usuarioPersisted.CEP = usuario.CEP;
        usuarioPersisted.Cidade = usuario.Cidade;
        usuarioPersisted.Bairro = usuario.Bairro;
        usuarioPersisted.Endereco = usuario.Endereco;
        
        await usuarioRepository.Save(usuarioPersisted);
        
        return validationResult;
    }
}