using CBF_API_Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Time> Times { get; set; }

        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<Transferencia> Transferencias { get; set; }

        public DbSet<Torneio> Torneios { get; set; }

        public DbSet<Partida> Partidas { get; set; }

        public DbSet<Evento> Eventos { get; set; }

       // public DbSet<TorneiosTimes> TorneiosTimes { get; set; }

       
        public ApiDbContext (DbContextOptions options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TorneiosTimes>()
            //    .HasKey(tt => new { tt.TimeId, tt.TorneioId });
        }


    }

}
