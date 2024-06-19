using CaronaUFF.Domain.Entities;
using CaronaUFF.Domain.Repositories;
using CaronaUFF.Domain.Services.Validation;

namespace CaronaUFF.Domain.Services;

public class VeiculoRegistration(IVeiculoRepository veiculoRepository)
{
    public async Task<ValidationResult<Veiculo>> Register(Veiculo veiculo)
    {
        var validationResult = await new VeiculoRegistrationValidation(veiculoRepository).Validate(veiculo);

        if (!validationResult.IsValid)
        {
            return validationResult;
        }

        await veiculoRepository.Save(veiculo);
        validationResult.Data = await veiculoRepository.GetVeiculo(v => v.Placa == veiculo.Placa);
        return validationResult;
    }

    public async Task<ValidationResult<Veiculo>> Update(Veiculo veiculo)
    {
        var validationResult = await new VeiculoRegistrationValidation(veiculoRepository).Validate(veiculo);

        if (!validationResult.IsValid)
        {
            return validationResult;
        }
        var veiculoPersisted = await veiculoRepository.GetById(veiculo.Id);
        veiculoPersisted.Modelo = veiculo.Modelo;
        veiculoPersisted.Placa = veiculo.Placa;
        veiculoPersisted.Cor = veiculo.Cor;
        veiculoPersisted.Ano = veiculo.Ano;
        veiculoPersisted.Marca = veiculo.Marca;

        validationResult.Data = veiculo;
        await veiculoRepository.Save(veiculoPersisted);
        return validationResult;
    }
}