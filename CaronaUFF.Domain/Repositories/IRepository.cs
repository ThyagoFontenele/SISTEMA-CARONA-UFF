using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.Repositories;

public interface IRepository<T> where T : IEntity
{
    Task<IList<T>> GetAll();
    Task<T?> GetById(int id);
    Task Save(T item);
    Task Delete(T item);
    Task Update(T item);
}