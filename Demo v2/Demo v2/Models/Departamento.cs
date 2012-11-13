using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Departamento
    {
        public virtual int DepartamentoId { get; set; }
        public virtual int FacultadId { get; set; }
        public virtual string Nombre { get; set; }

        public virtual Facultad Facultad { get; set; }
        public virtual List<TrabajaEn> TrabajaEn { get; set; }
    }
}