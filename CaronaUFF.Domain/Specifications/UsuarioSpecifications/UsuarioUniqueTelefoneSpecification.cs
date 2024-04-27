using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;

namespace CaronaUFF.Domain.Specifications.UsuarioSpecifications;

public class UsuarioUniqueTelefoneSpecification(IUsuarioRepository usuarioRepository) : ISpecification<Usuario>
{
    public string Message => "Telefone já cadastrado";

    public async Task<bool> IsSatisfiedBy(Usuario usuario) =>
        await usuarioRepository.GetUser(u => u.Telefone == usuario.Telefone) is null;
}