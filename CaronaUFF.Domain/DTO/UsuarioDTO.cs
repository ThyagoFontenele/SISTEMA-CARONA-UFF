using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.DTO;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } 
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Endereco { get; set; }
    public bool Administrador { get; set; }

    public static UsuarioDTO ToDTO(Usuario usuario) =>
        new UsuarioDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            CPF = usuario.CPF,
            DataNascimento = usuario.DataNascimento,
            Telefone = usuario.Telefone,
            CEP = usuario.CEP,
            Cidade = usuario.Cidade,
            Bairro = usuario.Bairro,
            Endereco = usuario.Endereco,
            Administrador = usuario.Administrador
        };
}