using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.Specifications;

public interface ISpecification<in T> where T : IEntity
{
    string Message { get; }
    Task<bool> IsSatisfiedBy(T entity);
}