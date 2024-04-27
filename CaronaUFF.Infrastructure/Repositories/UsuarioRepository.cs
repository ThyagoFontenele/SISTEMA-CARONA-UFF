using System.Linq.Expressions;
using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using NHibernate.Linq;

namespace CaronaUFF.Infrastructure.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public async Task<Usuario?> GetUser(Expression<Func<Usuario, bool>> predicate) =>
        await Session.Query<Usuario>()
            .FirstOrDefaultAsync(predicate);
}