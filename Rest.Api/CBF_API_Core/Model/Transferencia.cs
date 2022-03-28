using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Model
{
    public class Transferencia
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TimeDeOrigemId { get; set; }
       
        public Guid TimeDeDestinoId { get; set; }
       
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]  // Mostra apenas 2 casas decimais
        [Range(0, 9999999999999999.99)] //Máximo de 18 digitos
        public decimal ValorTransferencia { get; set; }

        public Guid JogadorTransferidoId { get; set; }
        
        public DateTime DataTransferencia { get; set; }

    }
}
