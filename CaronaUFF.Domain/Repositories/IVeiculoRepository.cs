using CaronaUFF.Domain.Entities;
using System.Linq.Expressions;

namespace CaronaUFF.Domain.Repositories;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<Veiculo?> GetVeiculo(Expression<Func<Veiculo, bool>> predicate); 
    Task<IList<Veiculo>> GetUserVeiculos(int userId);
}
