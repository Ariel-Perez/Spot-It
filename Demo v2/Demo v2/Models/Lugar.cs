using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Demo_v2.Models
{
    public class Lugar
    {
        [Key, Column(Order = 0)]
        public int idMapa { get; set; }
        [Key, Column(Order = 1)]
        public int idZona { get; set; }
        public string descripcion { get; set; }
    }
}