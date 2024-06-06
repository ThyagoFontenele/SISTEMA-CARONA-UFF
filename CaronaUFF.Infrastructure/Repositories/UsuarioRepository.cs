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
    
    public override async Task Save(Usuario usuario)
    {
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
        await Session.SaveAsync(usuario);
    }
}