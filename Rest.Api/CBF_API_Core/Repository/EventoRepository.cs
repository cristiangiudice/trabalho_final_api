using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using CBF_API_Core.Model;

namespace CBF_API_Core.Repository
{
    public class EventoRepository : IEventoRepository
    {
        IConfiguration _configuration;

        public EventoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
                            GetSection("DefaultConnection").Value;
            return connection;
        }

        public async Task<IEnumerable<Evento>> Get(Guid partidaid, int tipoEvento)
        {
            var connectionString = this.GetConnection();
            // Evento evento = new Evento();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT E.* FROM Eventos E WHERE E.PartidaId = '" + partidaid + "'" + " AND E.TipoEvento =" + tipoEvento + " ORDER BY DataEvento";
                var eventos = await con.QueryAsync<Evento>(query);

                return eventos;
            }
        }

        public async Task<int> Add(Evento evento)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Eventos([Id],[PartidaId],[TipoEvento],[DetalheEvento],[DataEvento]) VALUES(@Id, @PartidaId, @TipoEvento,@DetalheEvento,@DataEvento); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = await con.ExecuteAsync(query, evento);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
    }
}
