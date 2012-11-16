using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Demo_v2.Models
{
    public class Asiste
    {
        [Key, Column(Order = 0)]
        public int EventoId { get; set; }
        [Key, Column(Order = 1)]
        public int UsuarioId { get; set; }        
        public float Rating { get; set; }
    }
}
