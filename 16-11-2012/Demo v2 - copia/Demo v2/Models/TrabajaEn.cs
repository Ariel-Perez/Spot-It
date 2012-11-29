using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class TrabajaEn
    {
        public virtual int FacultadId { get; set; }
        public virtual int AutoridadId { get; set; }
        public virtual int DepartamentoId { get; set; }
        public virtual string Cargo { get; set; }

        public virtual Autoridad Autoridad { get; set; }
        public virtual Facultad Facultad { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}