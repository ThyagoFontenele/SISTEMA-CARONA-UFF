using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;

namespace CaronaUFF.Domain.Specifications.UsuarioSpecifications;

public class UsuarioUniqueEmailSpecification(IUsuarioRepository usuarioRepository) : ISpecification<Usuario>
{
    public string Message => "Email já cadastrado";

    public async Task<bool> IsSatisfiedBy(Usuario usuario) =>
        await usuarioRepository.GetUser(u => u.Id != usuario.Id && u.Email == usuario.Email) is null;
}