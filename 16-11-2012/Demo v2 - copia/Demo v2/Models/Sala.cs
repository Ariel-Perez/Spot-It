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
        public virtual int LugarId { get; set; }
        public virtual int Capacidad { get; set; }

        public virtual List<Horario> Horario { get; set; }
    }
}
