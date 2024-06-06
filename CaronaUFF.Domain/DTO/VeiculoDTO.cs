using CaronaUFF.Domain.Entities;

namespace CaronaUFF.Domain.DTO
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Marca { get; set; }

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
    }
}
