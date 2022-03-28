using GraphQl.API.Models;
using HotChocolate;
using JogadorReader;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQl.API.Queries
{
    public class Query
    {
        public async Task<List<JogadorReader.Jogador>> RetornaJogador([Service] JogadorService service,
                                    CancellationToken cancellationToken)
        {
            var retorno = await service.ApiJogadoresGetAsync();
            
            return retorno.ToList();

        }

        public async Task<List<JogadorReader.Time>> RetornaTime([Service] JogadorService service,
                                    CancellationToken cancellationToken)
        {
            var retorno = await service.ApiTimesGetAsync();

            return retorno.ToList();

        }
    }
}
