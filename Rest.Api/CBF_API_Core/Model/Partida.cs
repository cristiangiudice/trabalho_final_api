using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Model
{
    public class Partida
    {
        [Key]
        public Guid Id { get; set; }
              
        public Guid TorneioId { get; set; }
                
        public Guid Time_MandanteId { get; set; }
        
        public Guid Time_VisitanteId { get; set; }
       
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataPartida { get; set; }

        public int GolsTimeMandante { get; set; }

        public int GolsTimeVisitante { get; set; }

    }
}
