using CaronaUFF.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaronaUFF.Infrastructure.Mappings;

public class VeiculoMappingOverride : IAutoMappingOverride<Veiculo>
{
    public void Override(AutoMapping<Veiculo> mapping)
    {
        mapping.References(v => v.Usuario);
    }
}