using FluentNHibernate.Automapping;

namespace CaronaUFF.Infrastructure;

public class StoreConfiguration : DefaultAutomappingConfiguration
{
    public override bool ShouldMap(Type type) =>
        type.Namespace == "CaronaUFF.Domain.Entities";
    
    
}