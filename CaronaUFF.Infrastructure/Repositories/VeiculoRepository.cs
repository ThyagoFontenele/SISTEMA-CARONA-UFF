using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Infrastructure.Repositories
{
    public class VeiculoRepository : Repository<Veiculo> , IVeiculoRepository
    {
        public async Task<Veiculo?> GetVeiculo(Expression<Func<Veiculo, bool>> predicate) =>
    await Session.Query<Veiculo>()
        .FirstOrDefaultAsync(predicate);
    }
}
