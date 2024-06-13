using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.DTO
{
    public class VeiculoDTO
    {
        public required int Id { get; set; }
        public required string Placa { get; set; }
        public required string Modelo { get; set; }
        public required string Cor { get; set; }
        public required int Ano { get; set; }
        public required string Marca { get; set; }

        public static VeiculoDTO ToDTO(Veiculo veiculo) =>
            new VeiculoDTO
            {
                Id = veiculo.Id,
                Placa = veiculo.Placa,
                Modelo = veiculo.Modelo,
                Cor = veiculo.Cor,
                Ano = veiculo.Ano,
                Marca = veiculo.Marca,
            };
        
        public static Veiculo ToEntity(VeiculoDTO veiculo) =>
            new Veiculo
            {
                Id = veiculo.Id,
                Placa = veiculo.Placa,
                Modelo = veiculo.Modelo,
                Cor = veiculo.Cor,
                Ano = veiculo.Ano,
                Marca = veiculo.Marca,
            };
    }
}
