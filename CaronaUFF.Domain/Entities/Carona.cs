using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronaUFF.Domain.Entities
{
    public class Carona : IEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataHora { get; set; }
        public virtual int Vagas { get; set; }
        public virtual string Origem { get; set; }
        public virtual string Destino { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual bool Encerrada { get; set; }
        public virtual bool Cancelada { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual Carona? Retorno { get; set; }

        public virtual IList<Usuario> Passageiros { get; set; } = new List<Usuario>();
    }
}
