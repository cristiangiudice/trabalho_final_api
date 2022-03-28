using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Model
{
    public class Evento
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PartidaId { get; set; }

        public int TipoEvento { get; set; }

        [StringLength(300)]
        public string DetalheEvento { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEvento { get; set; }
    }
}
