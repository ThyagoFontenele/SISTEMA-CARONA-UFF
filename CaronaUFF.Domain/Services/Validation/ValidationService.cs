using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Specifications;

namespace CaronaUFF.Domain.Services.Validation;

public abstract class ValidationService<T> where T : IEntity
{
    protected abstract void SetValidations();

    protected ValidationService()
    {
        SetValidations();
    }
    
    private readonly IList<ISpecification<T>> specifications = new List<ISpecification<T>>();
    
    protected void AddSpecification(ISpecification<T> specification) =>
        specifications.Add(specification);

    public virtual async Task<ValidationResult<T>> Validate(T entity)
    {
        List<string> errors = new List<string>();
        foreach (var specification in specifications)
        {
            if (!(await specification.IsSatisfiedBy(entity)))
            {
                errors.Add(specification.Message);
            }
        }

        return new ValidationResult<T>(errors);
    }
}