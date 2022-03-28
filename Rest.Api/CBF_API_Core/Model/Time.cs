using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Model
{
    public class Time
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(60)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(1)]
        public string Serie { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(20)]
        public string Estado { get; set; }

       // public virtual ICollection<TorneiosTimes> TorneioTimes { get; set; }

    }
}
