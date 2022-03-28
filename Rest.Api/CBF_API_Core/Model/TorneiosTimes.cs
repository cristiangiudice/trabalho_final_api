using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CBF_API_Core.Model
{
    public class TorneiosTimes
    {
        public Guid TorneioId { get; set; }
        public Torneio Torneio { get; set; }

        public Guid TimeId { get; set; }
        public  Time Time { get; set; }
    }
}
