using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Demo_v2.Models
{
    public class Lugar_En_Categoria
    {
        [Key, Column(Order = 0)]
        public int idMapa { get; set; }
        public int idZona { get; set; }
        public string codigoComplejo { get; set; }
        [Key, Column(Order = 3)]
        public string codigo{ get; set; }
        public int capacidad { get; set; }
    }    
}