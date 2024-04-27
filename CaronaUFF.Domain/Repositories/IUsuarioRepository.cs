using System.Linq.Expressions;
using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario?> GetUser(Expression<Func<Usuario, bool>> predicate);
}