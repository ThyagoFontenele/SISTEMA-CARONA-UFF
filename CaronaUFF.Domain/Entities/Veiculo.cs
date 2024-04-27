namespace CaronaUFF.Domain.Entities;

public class Veiculo : IEntity
{
    public virtual int Id { get; set; }
    public virtual string Marca { get; set; }
    public virtual string Modelo { get; set; }
    public virtual string Cor { get; set; }
    public virtual string Placa { get; set; }
    public virtual int Ano { get; set; }
    public virtual Usuario Usuario { get; set; } 
}