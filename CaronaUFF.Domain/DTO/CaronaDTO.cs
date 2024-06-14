using CaronaUFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.DTO
{
    public class CaronaDTO
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataHora { get; set; }
        public virtual int Vagas { get; set; }
        public virtual string LocalSaida { get; set; }
        public virtual string LocalChegada { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual bool Encerrada { get; set; }
        public virtual bool Cancelada { get; set; }

        public static CaronaDTO ToDTO(Carona carona) =>
            new CaronaDTO
            {
                Id = carona.Id,
                DataHora = carona.DataHora,
                Vagas = carona.Vagas,
                LocalSaida = carona.Origem,
                LocalChegada = carona.Destino,
                Observacoes = carona.Observacoes,
                Encerrada = carona.Encerrada,
                Cancelada = carona.Cancelada
            };
    }
}
