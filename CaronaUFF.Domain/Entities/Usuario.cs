namespace CaronaUFF.Domain.Entities;

public class Usuario : IEntity
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; } 
    public virtual string Email { get; set; }
    public virtual string Senha { get; set; }
    public virtual string CPF { get; set; }
    public virtual DateTime DataNascimento { get; set; }
    public virtual string Telefone { get; set; }
    public virtual string CEP { get; set; }
    public virtual string Cidade { get; set; }
    public virtual string Bairro { get; set; }
    public virtual string Endereco { get; set; }
    public virtual bool Administrador { get; } = false;

    public virtual IList<Veiculo> Veiculos { get; } = new List<Veiculo>();
}
