using CaronaUFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Specifications.CaronaSpecifications
{
    public class CaronaVagasLengthSpecification : ISpecification<Carona>
    {
        public string Message => "O número de vagas deve ser maior que 0";
        public Task<bool> IsSatisfiedBy(Carona carona) =>
            Task.FromResult(carona.Vagas > 0);
    }
}
