using System;

namespace GraphQl.API.Models
{
    public class Time
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Serie { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
