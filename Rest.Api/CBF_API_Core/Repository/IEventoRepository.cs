using CBF_API_Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Repository
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> Get(Guid partidaid, int tipoEvento);

        Task< int> Add(Evento evento);
    }
}
