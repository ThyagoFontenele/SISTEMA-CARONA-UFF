using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.Services.Validation;

public class ValidationResult<T> where T : IEntity
{
    public T? Data { get; set; }

    public bool IsValid
    {
        get
        {
            if (Errors != null)
            {
                return !Errors.Any();
            }

            return true;
        }
    }

    public IList<string>? Errors { get; set; }

    public ValidationResult()
    {
    }

    public ValidationResult(IList<string> errors)
    {
        Errors = errors;
    }

    public ValidationResult(T data)
    {
        Data = data;
    }

    public void AddError(string error)
    {
        if (Errors == null)
        {
            IList<string> list2 = (Errors = new List<string>());
        }

        Errors!.Add(error);
    }
}