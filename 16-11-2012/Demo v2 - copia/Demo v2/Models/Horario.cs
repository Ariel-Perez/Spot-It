using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_v2.Models
{
    public class Horario
    {
        public virtual int LugarId { get; set; }
        public virtual int Modulo { get; set; }
        public virtual string Dia { get; set; }

        public virtual string curso { get; set; }
        public virtual string tipo_actividad { get; set; }
        public virtual DateTime fecha_ingreso { get; set; }

        public virtual Sala Sala { get; set; }
    }
}