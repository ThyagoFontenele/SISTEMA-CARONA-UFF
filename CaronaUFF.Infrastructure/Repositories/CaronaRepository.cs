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
    public class CaronaRepository : Repository<Carona>, ICaronaRepository
    {
        public async Task<Carona?> GetCarona(Expression<Func<Carona, bool>> predicate) =>
            await Session.Query<Carona>()
                .FirstOrDefaultAsync(predicate);
    }
}
