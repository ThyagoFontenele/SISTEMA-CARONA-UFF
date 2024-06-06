using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;

namespace CaronaUFF.Domain.Specifications.UsuarioSpecifications;

public class UsuarioUniqueCpfSpecification(IUsuarioRepository usuarioRepository) : ISpecification<Usuario>
{
    public string Message => "CPF já cadastrado";

    public async Task<bool> IsSatisfiedBy(Usuario usuario) =>
        await usuarioRepository.GetUser(u => u.Id != usuario.Id && u.CPF == usuario.CPF) is null;
}