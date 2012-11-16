using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Facultad
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }

        public virtual List<Departamento> Departamento { get; set; }
        public virtual List<Lugar> Lugar { get; set; }
        public virtual List<TrabajaEn> TrabajaEn { get; set; }
    }
}