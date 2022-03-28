using System;

namespace GraphQl.API.Models
{
    public class Jogador
    {
      
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Time Time { get; set; }
        public Guid TimeId { get; set; }
        public string Pais { get; set; }
    }
}
