using CaronaUFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Specifications.CaronaSpecifications
{
    public class CaronaDataHoraSpecification : ISpecification<Carona>
    {
        public string Message => "A data e hora da carona não pode ser menor que a data e hora atual";

        public Task<bool> IsSatisfiedBy(Carona carona) =>
            Task.FromResult(carona.DataHora > DateTime.Now);
    }
}
