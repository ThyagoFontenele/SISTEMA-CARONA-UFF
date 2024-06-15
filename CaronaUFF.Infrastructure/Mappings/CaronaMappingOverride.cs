using CaronaUFF.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Infrastructure.Mappings
{
    public class CaronaMappingOverride : IAutoMappingOverride<Carona>
    {
        public void Override(AutoMapping<Carona> mapping)
        {
            mapping.HasManyToMany(c => c.Passageiros).Table("CaronaPassageiros");
            mapping.References(c => c.Veiculo);
            mapping.References(c => c.Retorno);
        }
    }
}
