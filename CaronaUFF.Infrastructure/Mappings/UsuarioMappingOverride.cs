using CaronaUFF.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CaronaUFF.Infrastructure.Mappings;

public class UsuarioMappingOverride : IAutoMappingOverride<Usuario>
{
    public void Override(AutoMapping<Usuario> mapping)
    {
        mapping.HasMany(u => u.Veiculos).Cascade.All();
    }
}