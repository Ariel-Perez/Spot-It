using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Demo_v2.Models
{
    public class Sala
    {
        [Key, Column(Order = 0)]
        public int idMapa { get; set; }
        [Column(Order = 1)]
        public int idZona { get; set; }
        [Key, Column(Order = 3)]
        public string codigo{ get; set; }
    }
}
