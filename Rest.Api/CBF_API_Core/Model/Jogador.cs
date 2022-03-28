using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Model
{
    public class Jogador
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(60)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public DateTime DataNascimento { get; set; }

        public Time Time { get; set; }

        public Guid TimeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(30)]
        public string Pais { get; set; }
    }
}
