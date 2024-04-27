using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace CaronaUFF.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : IEntity
{
    protected ISession Session => FluentNhibernateHelper.GetCurrentSession();

    public async Task<IList<T>> GetAll() =>
        await Session.Query<T>().ToListAsync();

    public async Task<T> GetById(int id) =>
        await Session.GetAsync<T>(id);

    public virtual async Task Save(T item) =>
        await Session.SaveAsync(item);

    public async Task Delete(T item) =>
        await Session.DeleteAsync(item);

    public async Task Update(T item) =>
        await Session.UpdateAsync(item);
}