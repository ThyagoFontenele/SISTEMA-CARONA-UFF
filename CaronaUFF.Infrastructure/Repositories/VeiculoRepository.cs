using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace CaronaUFF.Infrastructure.Repositories;

public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
{
    public async Task<Veiculo?> GetVeiculo(Expression<Func<Veiculo, bool>> predicate) =>
         await Session.Query<Veiculo>().FirstOrDefaultAsync(predicate);

    public async Task<IList<Veiculo>> GetUserVeiculos(int userId) =>
        await Session.Query<Veiculo>()
            .Where(v => v.Usuario.Id == userId)
            .ToListAsync();
}
