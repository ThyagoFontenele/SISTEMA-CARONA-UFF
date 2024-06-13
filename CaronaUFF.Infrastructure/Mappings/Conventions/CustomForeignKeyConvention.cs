using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CaronaUFF.Infrastructure.Mappings.Conventions;

public class CustomForeignKeyConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention, IJoinedSubclassConvention
{
    public void Apply(IManyToOneInstance instance) => instance.Column($"{instance.Property.Name}Id");

    public void Apply(IOneToManyCollectionInstance instance)
    {
        if (instance.OtherSide is not null)
        {
            instance.Key.Column($"{instance.OtherSide.Property.Name}Id");
        }
    }

    public void Apply(IJoinedSubclassInstance instance) => instance.Key.Column("Id");

    public void Apply(IManyToManyCollectionInstance instance)
    {
        instance.Relationship.Column($"{instance.Relationship.Class.Name}Id");
        instance.Key.Column($"{instance.EntityType.Name}Id");
    }
}
