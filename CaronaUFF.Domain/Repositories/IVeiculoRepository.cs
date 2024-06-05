using CaronaUFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Repositories
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<Veiculo?> GetUser(Expression<Func<Veiculo, bool>> predicate);
    }
}
