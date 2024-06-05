using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Specifications.VeiculoSpecifications
{
    public class VeiculoUniquePlacaSpecification(IVeiculoRepository veiculoRepository) : ISpecification<Veiculo>
    {
        public string Message => "Placa já cadastrada";
        public async Task<bool> IsSatisfiedBy(Veiculo veiculo) =>
    await veiculoRepository.GetUser(u => u.Placa == veiculo.Placa) is null;
    }
}
