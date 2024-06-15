using CaronaUFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Repositories
{
    public interface ICaronaRepository : IRepository<Carona>
    {
        Task<Carona?> GetCarona(Expression<Func<Carona, bool>> predicate);
    }
}
