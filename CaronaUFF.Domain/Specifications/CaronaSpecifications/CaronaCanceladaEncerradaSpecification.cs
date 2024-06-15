using CaronaUFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Specifications.CaronaSpecifications
{
    public class CaronaCanceladaEncerradaSpecification : ISpecification<Carona>
    {
        public string Message => "A carona não pode estar cancelada e encerrada ao mesmo tempo";

        public Task<bool> IsSatisfiedBy(Carona carona) =>
            Task.FromResult(!(carona.Cancelada && carona.Encerrada));
    }
}
